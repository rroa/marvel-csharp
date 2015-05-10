using Marvel.Api.Results;
using RestSharp;

namespace Marvel.Api
{
    public partial class MarvelRestClient
    {
        private const string SeriesUrlSegment = "v1/public/series";

        /// <summary>
        /// Fetches lists of comic series with optional filters.
        /// </summary>        
        public virtual SeriesResult GetSeries()
        {
            var request = new RestRequest(SeriesUrlSegment, Method.GET);

            return Execute<SeriesResult>(request);
        }

        /// <summary>
        /// This method fetches a single comic series resource. 
        /// It is the canonical URI for any comic series resource provided by the API.
        /// </summary>
        /// <param name="seriesId">
        /// Series unique identifier
        /// </param>        
        public virtual SeriesResult GetSeries(string seriesId)
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}", SeriesUrlSegment, seriesId);

            var request = new RestRequest(requestUrl, Method.GET);

            return Execute<SeriesResult>(request);
        }

        /// <summary>
        /// Fetches lists of characters which appear in specific series, 
        /// with optional filters.
        /// </summary>
        /// <param name="seriesId">
        /// Series unique identifier
        /// </param>
        public virtual CharacterResult GetSeriesCharacters(string seriesId)
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/characters", SeriesUrlSegment, seriesId);

            var request = new RestRequest(requestUrl, Method.GET);

            return Execute<CharacterResult>(request);
        }

        /// <summary>
        /// Fetches lists of comics which are published as part of a specific series, 
        /// with optional filters.
        /// </summary>
        /// <param name="seriesId">
        /// Series unique identifier
        /// </param>
        public virtual ComicResult GetSeriesComics(string seriesId)
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/comics", SeriesUrlSegment, seriesId);

            var request = new RestRequest(requestUrl, Method.GET);

            return Execute<ComicResult>(request);
        }

        /// <summary>
        /// Fetches lists of comic creators whose work appears in a specific series, 
        /// with optional filters.
        /// </summary>
        /// <param name="seriesId">
        /// Series unique identifier
        /// </param>
        public virtual CreatorResult GetSeriesCreators(string seriesId)
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/creators", SeriesUrlSegment, seriesId);

            var request = new RestRequest(requestUrl, Method.GET);

            return Execute<CreatorResult>(request);
        }

        /// <summary>
        /// Fetches lists of events which occur in a specific series, 
        /// with optional filters.
        /// </summary>
        /// <param name="seriesId">
        /// Series unique identifier
        /// </param>
        public virtual EventResult GetSeriesEvents(string seriesId)
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/events", SeriesUrlSegment, seriesId);

            var request = new RestRequest(requestUrl, Method.GET);

            return Execute<EventResult>(request);
        }

        /// <summary>
        /// Fetches lists of comic stories from a specific series with optional filters.
        /// </summary>
        /// <param name="seriesId">
        /// Series unique identifier
        /// </param>
        public virtual StoryResult GetSeriesStories(string seriesId)
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/stories", SeriesUrlSegment, seriesId);

            var request = new RestRequest(requestUrl, Method.GET);

            return Execute<StoryResult>(request);
        }        
    }
}
