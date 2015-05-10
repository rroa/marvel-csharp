using Marvel.Api.Results;
using RestSharp;

namespace Marvel.Api
{
    public partial class MarvelRestClient
    {
        private const string EventsUrlSegment = "/public/events";

        /// <summary>
        /// Fetches lists of events with optional filters.
        /// </summary>
        /// <returns></returns>
        public virtual EventResult GetEvents()
        {
            var request = new RestRequest(EventsUrlSegment, Method.GET);

            return Execute<EventResult>(request);
        }

        /// <summary>
        /// This method fetches a single event resource. 
        /// It is the canonical URI for any event resource provided by the API.
        /// </summary>
        /// <param name="eventId">
        /// Event unique identifier
        /// </param>        
        public virtual EventResult GetEvent(string eventId)
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}", EventsUrlSegment, eventId);

            var request = new RestRequest(requestUrl, Method.GET);

            return Execute<EventResult>(request);
        }

        /// <summary>
        /// Fetches lists of characters which appear in a specific event, 
        /// with optional filters.
        /// </summary>
        /// <param name="eventId">
        /// Event unique identifier
        /// </param>        
        public virtual CharacterResult GetEventCharacters(string eventId)
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/characters", EventsUrlSegment, eventId);

            var request = new RestRequest(requestUrl, Method.GET);

            return Execute<CharacterResult>(request);
        }

        /// <summary>
        /// Fetches lists of comics which take place during a specific event, 
        /// with optional filters.
        /// </summary>
        /// <param name="eventId">
        /// Event unique identifier
        /// </param>        
        public virtual ComicResult GetEventComics(string eventId)
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/comics", EventsUrlSegment, eventId);

            var request = new RestRequest(requestUrl, Method.GET);

            return Execute<ComicResult>(request);
        }

        /// <summary>
        /// Fetches lists of comic creators whose work appears in a specific event, 
        /// with optional filters.
        /// </summary>
        /// <param name="eventId">
        /// Event unique identifier
        /// </param>        
        public virtual CreatorResult GetEventCreators(string eventId)
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/creators", EventsUrlSegment, eventId);

            var request = new RestRequest(requestUrl, Method.GET);

            return Execute<CreatorResult>(request);
        }

        /// <summary>
        /// Fetches lists of comic series in which a specific event takes place, 
        /// with optional filters.
        /// </summary>
        /// <param name="eventId">
        /// Event unique identifier
        /// </param>        
        public virtual SeriesResult GetEventSeries(string eventId)
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/series", EventsUrlSegment, eventId);

            var request = new RestRequest(requestUrl, Method.GET);

            return Execute<SeriesResult>(request);
        }

        /// <summary>
        /// Fetches lists of comic stories from a specific event, 
        /// with optional filters.
        /// </summary>
        /// <param name="eventId">
        /// Event unique identifier
        /// </param>        
        public virtual StoryResult GetEventStories(string eventId)
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/stories", EventsUrlSegment, eventId);

            var request = new RestRequest(requestUrl, Method.GET);

            return Execute<StoryResult>(request);
        }
    }
}
