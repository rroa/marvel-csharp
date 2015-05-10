using Marvel.Api.Model;
using RestSharp;

namespace Marvel.Api
{
    public partial class MarvelRestClient
    {
        private const string UrlSegment = "v1/public/characters";
        public virtual CharacterResult GetCharacters()
        {
            var request = new RestRequest(UrlSegment, Method.GET);

            return Execute<CharacterResult>(request);
        }

        public virtual CharacterResult GetCharacter(string characterId)
        {
            // Build request url
            //
            string requestUrl = 
                string.Format("{0}/{1}", UrlSegment, characterId);

            var request = new RestRequest(requestUrl, Method.GET);

            return Execute<CharacterResult>(request);
        }

        public virtual CharacterResult GetCharacterComics(string characterId)
        {
            // Build request url
            //
            string requestUrl = 
                string.Format("{0}/{1}/comics", UrlSegment, characterId);

            var request = new RestRequest(requestUrl, Method.GET);

            return Execute<CharacterResult>(request);
        }
    }
}
