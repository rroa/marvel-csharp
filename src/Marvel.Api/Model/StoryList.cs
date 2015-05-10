using System.Collections.Generic;

namespace Marvel.Api.Model
{
    public class StoryList
    {
        public string Available { get; set; }
        public string Returned { get; set; }
        public string CollectionURI { get; set; }
        public List<StorySummary> Items { get; set; }
    }    
}
