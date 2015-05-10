using Marvel.Api.Filters;
using Marvel.Api.Results;
using RestSharp;

namespace Marvel.Api
{
    public partial class MarvelRestClient
    {
        private const string StoriesUrlSegment = "/public/stories";

        /// <summary>
        /// Fetches lists of comic stories with optional filters. 
        /// </summary>        
        public virtual StoryResult GetStories()
        {
            var request = new RestRequest(StoriesUrlSegment, Method.GET);

            return Execute<StoryResult>(request);
        }

        /// <summary>
        /// This method fetches a single comic story resource. 
        /// It is the canonical URI for any comic story resource provided by the API.
        /// </summary>
        /// <param name="storyId">
        /// Story unique identifier
        /// </param>        
        public virtual StoryResult GetStory(string storyId)
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}", StoriesUrlSegment, storyId);

            var request = new RestRequest(requestUrl, Method.GET);

            return Execute<StoryResult>(request);
        }

        /// <summary>
        /// Fetches lists of comic characters appearing in a single story, 
        /// with optional filters.
        /// </summary>
        /// <param name="storyId">
        /// Story unique identifier
        /// </param> 
        /// <param name="filter">
        /// Search query filter data
        /// </param>
        public virtual CharacterResult GetStoryCharacters(string storyId, CharacterRequestFilter filter = default(CharacterRequestFilter))
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/characters", StoriesUrlSegment, storyId);

            var request = new RestRequest(requestUrl, Method.GET);

            // Parse filter
            //
            ParseCharacterFilter(request, filter);

            return Execute<CharacterResult>(request);
        }

        /// <summary>
        /// Fetches lists of comics in which a specific story appears, 
        /// with optional filters.
        /// </summary>
        /// <param name="storyId">
        /// Story unique identifier
        /// </param> 
        /// <param name="filter">
        /// Search query filter data
        /// </param>
        public virtual ComicResult GetStoryComics(string storyId, ComicRequestFilter filter = default(ComicRequestFilter))
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/comics", StoriesUrlSegment, storyId);

            var request = new RestRequest(requestUrl, Method.GET);

            // Parse filter
            //
            ParseComicFilter(request, filter);

            return Execute<ComicResult>(request);
        }

        /// <summary>
        /// Fetches lists of comic creators whose work appears in a specific story, 
        /// with optional filters.
        /// </summary>
        /// <param name="storyId">
        /// Story unique identifier
        /// </param> 
        public virtual CreatorResult GetStoryCreators(string storyId)
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/creators", StoriesUrlSegment, storyId);

            var request = new RestRequest(requestUrl, Method.GET);

            return Execute<CreatorResult>(request);
        }

        /// <summary>
        /// Fetches lists of events in which a specific story appears, 
        /// with optional filters.
        /// </summary>
        /// <param name="storyId">
        /// Story unique identifier
        /// </param> 
        public virtual EventResult GetStoryEvents(string storyId)
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/events", StoriesUrlSegment, storyId);

            var request = new RestRequest(requestUrl, Method.GET);

            return Execute<EventResult>(request);
        }

        /// <summary>
        /// Fetches lists of comic series in which the specified story takes place.
        /// </summary>
        /// <param name="storyId">
        /// Story unique identifier
        /// </param> 
        public virtual SeriesResult GetStorySeries(string storyId)
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/series", StoriesUrlSegment, storyId);

            var request = new RestRequest(requestUrl, Method.GET);

            return Execute<SeriesResult>(request);
        }
    }
}
