using System;
using System.Globalization;
using System.Reflection;
using System.Text;
using Marvel.Api.Filters;
using RestSharp;
using RestSharp.Extensions;

namespace Marvel.Api
{
    public abstract partial class MarvelClient
    {
        protected RestClient Client;
        protected readonly string ApiPublicKey;
        protected readonly string ApiPrivateKey;

        protected MarvelClient(string apiPublicKey, string apiPrivateKey, string apiVersion, string baseUrl)
        {
            // Setting properties
            //
            ApiVersion = apiVersion;
            BaseUrl = baseUrl;
            DateFormat = "ddd, dd MMM yyyy HH:mm:ss '+0000'";

            // Setting members
            //
            ApiPublicKey = apiPublicKey;
            ApiPrivateKey = apiPrivateKey;            

            // Getting current assembly version
            //
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyName = new AssemblyName(assembly.FullName);
            var version = assemblyName.Version;

            Client = new RestClient
            {
                BaseUrl = new Uri(string.Format("{0}{1}", BaseUrl, ApiVersion)),
                UserAgent = string.Format("marvel-csharp/{0} (.NET {1})", 
                                           version, 
                                           Environment.Version),
                Timeout = 30500
            };
        }

        /// <summary>
        /// Sets request auth parameters
        /// </summary>        
        private void SetAuthInfo(IRestRequest request)
        {
            // Timestamp
            string ts = Util.UnixTimeNow().ToString(CultureInfo.InvariantCulture);

            // md5 digest
            string hashInput = ts + ApiPrivateKey + ApiPublicKey;
            string hash = Util.CalculateMd5Hash(hashInput).ToLower();

            // Authentication params
            request.AddParameter("ts", ts);
            request.AddParameter("apikey", ApiPublicKey);
            request.AddParameter("hash", hash);
        }

        /// <summary>
        /// Execute a manual REST request
        /// </summary>
        /// <typeparam name="T">The type of object to create and populate with the returned data.</typeparam>
        /// <param name="request">The RestRequest to execute (will use client credentials)</param>
        public virtual T Execute<T>(IRestRequest request) where T : new()
        {
            request.OnBeforeDeserialization = resp =>
            {
                // for individual resources when there's an error to make
                // sure that RestException props are populated
                if (((int)resp.StatusCode) >= 400)
                {
                    // have to read the bytes so .Content doesn't get populated
                    const string restException = "{{ \"RestException\" : {0} }}";
                    var content = resp.RawBytes.AsString(); //get the response content
                    var newJson = string.Format(restException, content);

                    resp.Content = null;
                    resp.RawBytes = Encoding.UTF8.GetBytes(newJson.ToString(CultureInfo.InvariantCulture));
                }
            };

            // Setting auth info
            //
            SetAuthInfo(request);

            // Setting date format
            //
            request.DateFormat = DateFormat;
            
            var response = Client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var marvelException = new ApplicationException(message, response.ErrorException);
                throw marvelException;
            }

            return response.Data;
        }

        /// <summary>
        /// Execute a manual REST request
        /// </summary>
        /// <param name="request">The RestRequest to execute (will use client credentials)</param>
        public virtual IRestResponse Execute(IRestRequest request)
        {
            return Client.Execute(request);
        }

        #region Properties
        /// <summary>
        /// Base URL of API
        /// </summary>
        public string BaseUrl { get; private set; }

        /// <summary>
        /// Marvel API version to use when making requests
        /// </summary>
        public string ApiVersion { get; private set; }

        protected string DateFormat { get; set; }
        #endregion
    }

    /// <summary>
    /// REST API wrapper.
    /// </summary>
    public partial class MarvelRestClient : MarvelClient
    {
        /// <summary>
        /// Initializes a new client with the specified credentials
        /// </summary>
        /// <param name="apiPublicKey">
        /// API public key
        /// </param>
        /// <param name="apiPrivateKey">
        /// API private key
        /// </param>        
        public MarvelRestClient(string apiPublicKey, string apiPrivateKey) :
            base(apiPublicKey, apiPrivateKey, "v1", "http://gateway.marvel.com/")
        { }

        #region Helpers
        private void ParseCharacterFilter(IRestRequest request, CharacterRequestFilter filter)
        {
            if (filter != null)
            {
                if (filter.Name.HasValue()) request.AddParameter("name", filter.Name);
                if (filter.NameStartsWith.HasValue()) request.AddParameter("nameStartsWith", filter.NameStartsWith);
                if (filter.ModifiedSince.HasValue) request.AddParameter("modifiedSince", filter.ModifiedSince.Value.ToString("yyyy-MM-dd"));
                if (filter.Comics.HasValue()) request.AddParameter("comics", filter.Comics);
                if (filter.Series.HasValue()) request.AddParameter("series", filter.Series);
                if (filter.Events.HasValue()) request.AddParameter("events", filter.Events);    
                if (filter.Stories.HasValue()) request.AddParameter("stories", filter.Stories);                        
                if (filter.ResultSetOrder.HasValue()) request.AddParameter("orderBy", filter.ResultSetOrder);
                if (filter.Limit.HasValue) request.AddParameter("limit", filter.Limit.Value);
                if (filter.Offset.HasValue) request.AddParameter("offset", filter.Offset.Value);                    
            }
        }
        #endregion
    }
}
