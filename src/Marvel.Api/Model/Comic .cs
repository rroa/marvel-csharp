using System.Collections.Generic;

namespace Marvel.Api.Model
{
    public class Comic
    {
        public string Id { get; set; }
        public string DigitalId { get; set; }
        public string Title { get; set; }
        public string IssueNumber { get; set; }
        public string VariantDescription { get; set; }
        public string Description { get; set; }
        public string Modified { get; set; }
        public string ISBN { get; set; }
        public string UPC { get; set; }
        public string DiamondCode { get; set; }
        public string EAN { get; set; }
        public string ISSN { get; set; }
        public string Format { get; set; }
        public string PageCount { get; set; }
        public List<TextObject> TextObjects { get; set; }
        public string ResourceURI { get; set; }
        public List<Url> Urls { get; set; }
        public SeriesSummary Series { get; set; }
        public List<Variant> Variants { get; set; }
        public List<Collection> Collections { get; set; }
        public List<CollectedIssue> CollectedIssues { get; set; }
        public List<Date> Dates { get; set; }
        public List<Price> Prices { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public List<Image> Images { get; set; }
        public CreatorList Creators { get; set; }
        public CharacterList Characters { get; set; }
        public StoryList Stories { get; set; }
        public EventList Events { get; set; }
    }
}
