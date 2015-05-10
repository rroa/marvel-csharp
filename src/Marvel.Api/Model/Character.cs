using System.Collections.Generic;

namespace Marvel.Api.Model
{
    public class Character
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Modified { get; set; }
        public string ResourceURI { get; set; }
        public List<Url> Urls { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public ComicList Comics { get; set; }
        public StoryList Stories { get; set; }
        public EventList Events { get; set; }
        public SeriesList Series { get; set; }
    }  
}
