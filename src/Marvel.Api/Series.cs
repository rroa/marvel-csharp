using Marvel.Api.Filters;
using Marvel.Api.Results;
using RestSharp;

namespace Marvel.Api
{
    public partial class MarvelRestClient
    {
        private const string SeriesUrlSegment = "/public/series";

        /// <summary>
        /// Fetches lists of comic series with optional filters.
        /// </summary>
        /// <param name="filter">
        /// Search query filter data
        /// </param>  
        public virtual SeriesResult GetSeries(SeriesRequestFilter filter = default(SeriesRequestFilter))
        {
            var request = new RestRequest(SeriesUrlSegment, Method.GET);

            // Parse filter
            //
            ParseSeriesFilter(request, filter);

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
        /// <param name="filter">
        /// Search query filter data
        /// </param>
        public virtual CharacterResult GetSeriesCharacters(string seriesId, CharacterRequestFilter filter = default(CharacterRequestFilter))
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/characters", SeriesUrlSegment, seriesId);

            var request = new RestRequest(requestUrl, Method.GET);

            // Parse filter
            //
            ParseCharacterFilter(request, filter);

            return Execute<CharacterResult>(request);
        }

        /// <summary>
        /// Fetches lists of comics which are published as part of a specific series, 
        /// with optional filters.
        /// </summary>
        /// <param name="seriesId">
        /// Series unique identifier
        /// </param>
        /// <param name="filter">
        /// Search query filter data
        /// </param>
        public virtual ComicResult GetSeriesComics(string seriesId, ComicRequestFilter filter = default(ComicRequestFilter))
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/comics", SeriesUrlSegment, seriesId);

            var request = new RestRequest(requestUrl, Method.GET);

            // Parse filter
            //
            ParseComicFilter(request, filter);

            return Execute<ComicResult>(request);
        }

        /// <summary>
        /// Fetches lists of comic creators whose work appears in a specific series, 
        /// with optional filters.
        /// </summary>
        /// <param name="seriesId">
        /// Series unique identifier
        /// </param>
        /// <param name="filter">
        /// Search query filter data
        /// </param>
        public virtual CreatorResult GetSeriesCreators(string seriesId, CreatorRequestFilter filter = default(CreatorRequestFilter))
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/creators", SeriesUrlSegment, seriesId);

            var request = new RestRequest(requestUrl, Method.GET);

            // Parse filter
            //
            ParseCreatorFilter(request, filter);

            return Execute<CreatorResult>(request);
        }

        /// <summary>
        /// Fetches lists of events which occur in a specific series, 
        /// with optional filters.
        /// </summary>
        /// <param name="seriesId">
        /// Series unique identifier
        /// </param>
        /// <param name="filter">
        /// Search query filter data
        /// </param>
        public virtual EventResult GetSeriesEvents(string seriesId, EventRequestFilter filter = default(EventRequestFilter))
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/events", SeriesUrlSegment, seriesId);

            var request = new RestRequest(requestUrl, Method.GET);

            // Parse filter
            //
            ParseEventFilter(request, filter);

            return Execute<EventResult>(request);
        }

        /// <summary>
        /// Fetches lists of comic stories from a specific series with optional filters.
        /// </summary>
        /// <param name="seriesId">
        /// Series unique identifier
        /// </param>
        /// <param name="filter">
        /// Search query filter data
        /// </param>
        public virtual StoryResult GetSeriesStories(string seriesId, StoryRequestFilter filter = default(StoryRequestFilter))
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/stories", SeriesUrlSegment, seriesId);

            var request = new RestRequest(requestUrl, Method.GET);

            // Parse filter
            //
            ParseStoryFilter(request, filter);

            return Execute<StoryResult>(request);
        }        
    }
}
