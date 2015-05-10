using Marvel.Api.Results;
using RestSharp;

namespace Marvel.Api
{
    public partial class MarvelRestClient
    {
        private const string CharactersUrlSegment = "/public/characters";

        /// <summary>
        /// Fetches lists of comic characters with optional filters.
        /// </summary>        
        public virtual CharacterResult GetCharacters()
        {
            var request = new RestRequest(CharactersUrlSegment, Method.GET);

            return Execute<CharacterResult>(request);
        }

        /// <summary>
        /// This method fetches a single character resource. 
        /// It is the canonical URI for any character resource provided by the API.
        /// </summary>
        /// <param name="characterId">
        /// Character unique identifier
        /// </param>        
        public virtual CharacterResult GetCharacter(string characterId)
        {
            // Build request url
            //
            string requestUrl = 
                string.Format("{0}/{1}", CharactersUrlSegment, characterId);

            var request = new RestRequest(requestUrl, Method.GET);            

            return Execute<CharacterResult>(request);
        }

        /// <summary>
        /// Fetches lists of comics containing a specific character, 
        /// with optional filters.
        /// </summary>
        /// <param name="characterId">
        /// Character unique identifier
        /// </param>
        public virtual ComicResult GetCharacterComics(string characterId)
        {
            // Build request url
            //
            string requestUrl = 
                string.Format("{0}/{1}/comics", CharactersUrlSegment, characterId);

            var request = new RestRequest(requestUrl, Method.GET);

            return Execute<ComicResult>(request);
        }

        /// <summary>
        /// Fetches lists of events in which a specific character appears, 
        /// with optional filters.
        /// </summary>
        /// <param name="characterId">
        /// Character unique identifier
        /// </param>
        public virtual EventResult GetCharacterEvents(string characterId)
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/events", CharactersUrlSegment, characterId);

            var request = new RestRequest(requestUrl, Method.GET);

            return Execute<EventResult>(request);
        }

        /// <summary>
        /// Fetches lists of comic series in which a specific character appears, 
        /// with optional filters.
        /// </summary>
        /// <param name="characterId">
        /// Character unique identifier
        /// </param>
        public virtual SeriesResult GetCharacterSeries(string characterId)
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/series", CharactersUrlSegment, characterId);

            var request = new RestRequest(requestUrl, Method.GET);

            return Execute<SeriesResult>(request);
        }

        /// <summary>
        /// Fetches lists of comic stories featuring a specific character with optional filters.
        /// </summary>
        /// <param name="characterId">
        /// Character unique identifier
        /// </param>
        public virtual StoryResult GetCharacterStories(string characterId)
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/stories", CharactersUrlSegment, characterId);

            var request = new RestRequest(requestUrl, Method.GET);

            return Execute<StoryResult>(request);
        }
    }
}
