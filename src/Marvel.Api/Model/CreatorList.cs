using System.Collections.Generic;

namespace Marvel.Api.Model
{
    public class CreatorList
    {
        public string Available { get; set; }
        public string Returned { get; set; }
        public string CollectionURI { get; set; }
        public List<CreatorSummary> Items { get; set; }    
    }
}
