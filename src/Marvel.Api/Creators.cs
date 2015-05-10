using Marvel.Api.Filters;
using Marvel.Api.Results;
using RestSharp;

namespace Marvel.Api
{
    public partial class MarvelRestClient
    {
        private const string CreatorsUrlSegment = "/public/creators";

        /// <summary>
        /// Fetches lists of comic creators with optional filters.
        /// </summary>
        /// <param name="filter">
        /// Search query filter data
        /// </param>    
        public virtual CreatorResult GetCreators(CreatorRequestFilter filter = default(CreatorRequestFilter))
        {
            var request = new RestRequest(CreatorsUrlSegment, Method.GET);

            // Parse filter
            //
            ParseCreatorFilter(request, filter);

            return Execute<CreatorResult>(request);
        }

        /// <summary>
        /// This method fetches a single creator resource. 
        /// It is the canonical URI for any creator resource provided by the API.
        /// </summary>
        /// <param name="creatorId">
        /// Creator unique identifier
        /// </param>        
        public virtual CreatorResult GetCreator(string creatorId)
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}", CreatorsUrlSegment, creatorId);

            var request = new RestRequest(requestUrl, Method.GET);

            return Execute<CreatorResult>(request);
        }

        /// <summary>
        /// Fetches lists of comics in which the work of a specific creator appears, 
        /// with optional filters.
        /// </summary>
        /// <param name="creatorId">
        /// Creator unique identifier
        /// </param> 
        /// <param name="filter">
        /// Search query filter data
        /// </param>
        public virtual ComicResult GetCreatorComics(string creatorId, ComicRequestFilter filter = default(ComicRequestFilter))
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/comics", CreatorsUrlSegment, creatorId);

            var request = new RestRequest(requestUrl, Method.GET);

            // Parse filter
            //
            ParseComicFilter(request, filter);

            return Execute<ComicResult>(request);
        }

        /// <summary>
        /// Fetches lists of events featuring the work of a specific creator with optional filters.
        /// </summary>
        /// <param name="creatorId">
        /// Creator unique identifier
        /// </param> 
        /// <param name="filter">
        /// Search query filter data
        /// </param>
        public virtual EventResult GetCreatorEvents(string creatorId, EventRequestFilter filter = default(EventRequestFilter))
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/events", CreatorsUrlSegment, creatorId);

            var request = new RestRequest(requestUrl, Method.GET);

            // Parse filter
            //
            ParseEventFilter(request, filter);

            return Execute<EventResult>(request);
        }

        /// <summary>
        /// Fetches lists of comic series in which a specific creator's work appears, 
        /// with optional filters.
        /// </summary>
        /// <param name="creatorId">
        /// Creator unique identifier
        /// </param> 
        /// <param name="filter">
        /// Search query filter data
        /// </param>
        public virtual SeriesResult GetCreatorSeries(string creatorId, SeriesRequestFilter filter = default(SeriesRequestFilter))
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/series", CreatorsUrlSegment, creatorId);

            var request = new RestRequest(requestUrl, Method.GET);

            // Parse filter
            //
            ParseSeriesFilter(request, filter);

            return Execute<SeriesResult>(request);
        }

        /// <summary>
        /// Fetches lists of comic stories by a specific creator with optional filters.
        /// </summary>
        /// <param name="creatorId">
        /// Creator unique identifier
        /// </param> 
        /// <param name="filter">
        /// Search query filter data
        /// </param>
        public virtual StoryResult GetCreatorStories(string creatorId, StoryRequestFilter filter = default(StoryRequestFilter))
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/stories", CreatorsUrlSegment, creatorId);

            var request = new RestRequest(requestUrl, Method.GET);

            // Parse filter
            //
            ParseStoryFilter(request, filter);

            return Execute<StoryResult>(request);
        }
    }
}
