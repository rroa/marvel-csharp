using System.Collections.Generic;

namespace Marvel.Api.Model
{
    public class ComicList
    {
        public string Available { get; set; }
        public string Returned { get; set; }
        public string CollectionURI { get; set; }
        public List<ComicSummary> Items { get; set; }
    }    
}
