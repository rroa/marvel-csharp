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

        private void ParseComicFilter(IRestRequest request, ComicRequestFilter filter)
        {
            if (filter != null)
            {
                if (filter.Format.HasValue) request.AddParameter("format", filter.Format.Value.GetDescription());
                if (filter.FormatType.HasValue) request.AddParameter("formatType", filter.FormatType.Value.GetDescription());
                if (filter.NoVariants.HasValue) request.AddParameter("noVariants", filter.NoVariants.Value.ToString().ToLower());
                if (filter.DateDescriptor.HasValue) request.AddParameter("dateDescriptor", filter.DateDescriptor.Value.GetDescription());
                if (filter.DateRange.HasValue()) request.AddParameter("dateRange", filter.DateRange);
                if (filter.Title.HasValue()) request.AddParameter("title", filter.Title);
                if (filter.TitleStartsWith.HasValue()) request.AddParameter("titleStartsWith", filter.TitleStartsWith);
                if (filter.StartYear.HasValue) request.AddParameter("startYear", filter.StartYear.Value);
                if (filter.IssueNumber.HasValue) request.AddParameter("issueNumber", filter.IssueNumber.Value);
                if (filter.DiamondCode.HasValue()) request.AddParameter("diamondCode", filter.DiamondCode);
                if (filter.DigitalId.HasValue) request.AddParameter("digitalId", filter.DigitalId.Value);
                if (filter.UPC.HasValue()) request.AddParameter("upc", filter.UPC);
                if (filter.ISBN.HasValue()) request.AddParameter("isbn", filter.ISBN);
                if (filter.EAN.HasValue()) request.AddParameter("ean", filter.EAN);
                if (filter.ISSN.HasValue()) request.AddParameter("issn", filter.ISSN);
                if (filter.HasDigitalIssue.HasValue) request.AddParameter("hasDigitalIssue", filter.HasDigitalIssue.ToString().ToLower());
                if (filter.ModifiedSince.HasValue) request.AddParameter("modifiedSince", filter.ModifiedSince.Value.ToString("yyyy-MM-dd"));
                if (filter.Creators.HasValue()) request.AddParameter("creators", filter.Creators);
                if (filter.Characters.HasValue()) request.AddParameter("characters", filter.Characters);                
                if (filter.Series.HasValue()) request.AddParameter("series", filter.Series);
                if (filter.Events.HasValue()) request.AddParameter("events", filter.Events);
                if (filter.Stories.HasValue()) request.AddParameter("stories", filter.Stories);
                if (filter.SharedAppearances.HasValue()) request.AddParameter("sharedAppearances", filter.SharedAppearances);
                if (filter.Collaborators.HasValue()) request.AddParameter("collaborators", filter.Collaborators);
                if (filter.ResultSetOrder.HasValue()) request.AddParameter("orderBy", filter.ResultSetOrder);
                if (filter.Limit.HasValue) request.AddParameter("limit", filter.Limit.Value);
                if (filter.Offset.HasValue) request.AddParameter("offset", filter.Offset.Value);
            }            
        }

        private void ParseCreatorFilter(IRestRequest request, CreatorRequestFilter filter)
        {
            if (filter != null)
            {
                if (filter.FirstName.HasValue()) request.AddParameter("firstName", filter.FirstName);
                if (filter.MiddleName.HasValue()) request.AddParameter("middleName", filter.MiddleName);
                if (filter.LastName.HasValue()) request.AddParameter("lastName", filter.LastName);
                if (filter.Suffix.HasValue()) request.AddParameter("suffix", filter.Suffix);
                if (filter.NameStartsWith.HasValue()) request.AddParameter("nameStartsWith", filter.NameStartsWith);
                if (filter.FirstNameStartsWith.HasValue()) request.AddParameter("firstNameStartsWith", filter.FirstNameStartsWith);
                if (filter.MiddleNameStartsWith.HasValue()) request.AddParameter("middleNameStartsWith", filter.MiddleNameStartsWith);
                if (filter.LastNameStartsWith.HasValue()) request.AddParameter("lastNameStartsWith", filter.LastNameStartsWith);
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

        private void ParseEventFilter(IRestRequest request, EventRequestFilter filter)
        {
            if (filter != null)
            {
                if (filter.Name.HasValue()) request.AddParameter("name", filter.Name);
                if (filter.NameStartsWith.HasValue()) request.AddParameter("nameStartsWith", filter.NameStartsWith);
                if (filter.ModifiedSince.HasValue) request.AddParameter("modifiedSince", filter.ModifiedSince.Value.ToString("yyyy-MM-dd"));
                if (filter.Creators.HasValue()) request.AddParameter("creators", filter.Creators);
                if (filter.Characters.HasValue()) request.AddParameter("characters", filter.Characters);
                if (filter.Series.HasValue()) request.AddParameter("series", filter.Series);
                if (filter.Comics.HasValue()) request.AddParameter("comics", filter.Comics);
                if (filter.Stories.HasValue()) request.AddParameter("stories", filter.Stories);
                if (filter.ResultSetOrder.HasValue()) request.AddParameter("orderBy", filter.ResultSetOrder);
                if (filter.Limit.HasValue) request.AddParameter("limit", filter.Limit.Value);
                if (filter.Offset.HasValue) request.AddParameter("offset", filter.Offset.Value);     
            }
        }

        private void ParseSeriesFilter(IRestRequest request, SeriesRequestFilter filter)
        {
            if (filter != null)
            {
                if (filter.Title.HasValue()) request.AddParameter("title", filter.Title);
                if (filter.TitleStartsWith.HasValue()) request.AddParameter("titleStartsWith", filter.TitleStartsWith);
                if (filter.StartYear.HasValue) request.AddParameter("startYear", filter.StartYear.Value);
                if (filter.ModifiedSince.HasValue) request.AddParameter("modifiedSince", filter.ModifiedSince.Value.ToString("yyyy-MM-dd"));
                if (filter.Comics.HasValue()) request.AddParameter("comics", filter.Comics);
                if (filter.Stories.HasValue()) request.AddParameter("stories", filter.Stories);                
                if (filter.Events.HasValue()) request.AddParameter("events", filter.Events);
                if (filter.Creators.HasValue()) request.AddParameter("creators", filter.Creators);
                if (filter.Characters.HasValue()) request.AddParameter("characters", filter.Characters);
                if (filter.SeriesType.HasValue) request.AddParameter("seriesType", filter.SeriesType.HasValue.GetDescription());
                if (filter.Contains.HasValue()) request.AddParameter("contains", filter.Contains);
                if (filter.ResultSetOrder.HasValue()) request.AddParameter("orderBy", filter.ResultSetOrder);
                if (filter.Limit.HasValue) request.AddParameter("limit", filter.Limit.Value);
                if (filter.Offset.HasValue) request.AddParameter("offset", filter.Offset.Value);
            }
        }

        private void ParseStoryFilter(IRestRequest request, StoryRequestFilter filter)
        {
            if (filter != null)
            {
                if (filter.ModifiedSince.HasValue) request.AddParameter("modifiedSince", filter.ModifiedSince.Value.ToString("yyyy-MM-dd"));
                if (filter.Comics.HasValue()) request.AddParameter("comics", filter.Comics);
                if (filter.Series.HasValue()) request.AddParameter("series", filter.Series);
                if (filter.Events.HasValue()) request.AddParameter("events", filter.Events);
                if (filter.Creators.HasValue()) request.AddParameter("creators", filter.Creators);
                if (filter.Characters.HasValue()) request.AddParameter("characters", filter.Characters);                
                if (filter.ResultSetOrder.HasValue()) request.AddParameter("orderBy", filter.ResultSetOrder);
                if (filter.Limit.HasValue) request.AddParameter("limit", filter.Limit.Value);
                if (filter.Offset.HasValue) request.AddParameter("offset", filter.Offset.Value);
            }
        }

        #endregion
    }
}
