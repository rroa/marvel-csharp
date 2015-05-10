using System.Collections.Generic;
using Marvel.Api.Model.Summaries;

namespace Marvel.Api.Model.Lists
{
    public class CharacterList
    {
        public string Available { get; set; }
        public string Returned { get; set; }
        public string CollectionURI { get; set; }
        public List<CharacterSummary> Items { get; set; }
    }
}
