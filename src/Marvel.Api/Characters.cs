using Marvel.Api.Model;
using RestSharp;

namespace Marvel.Api
{
    public partial class MarvelRestClient
    {
        public virtual DataWrapper GetCharacters()
        {
            var request = new RestRequest("v1/public/characters", Method.GET);
            return Execute<DataWrapper>(request);
        }

        public virtual DataWrapper GetCharacter(string characterId)
        {
            var request = new RestRequest(string.Format("v1/public/characters/{0}", characterId), Method.GET);
            return Execute<DataWrapper>(request);
        }
    }
}
