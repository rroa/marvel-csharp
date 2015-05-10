using System.Collections.Generic;

namespace Marvel.Api.Model
{
    public class TextObject
    {
        public string type { get; set; }
        public string language { get; set; }
        public string text { get; set; }
    }

    public class Series
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
    }

    public class Variant
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
    }

    public class Collection
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
    }

    public class CollectedIssue
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
    }

    public class Date
    {
        public string type { get; set; }
        public string date { get; set; }
    }

    public class Price
    {
        public string type { get; set; }
        public string price { get; set; }
    }

    public class Image
    {
        public string path { get; set; }
        public string extension { get; set; }
    }

    public class Item
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
        public string role { get; set; }
    }

    public class Creators
    {
        public string available { get; set; }
        public string returned { get; set; }
        public string collectionURI { get; set; }
        public List<Item> items { get; set; }
    }

    public class Item2
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
        public string role { get; set; }
    }

    public class Characters
    {
        public string available { get; set; }
        public string returned { get; set; }
        public string collectionURI { get; set; }
        public List<Item2> items { get; set; }
    }

    public class Item3
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }

    public class Stories
    {
        public string available { get; set; }
        public string returned { get; set; }
        public string collectionURI { get; set; }
        public List<Item3> items { get; set; }
    }

    public class Item4
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
    }

    public class Events
    {
        public string available { get; set; }
        public string returned { get; set; }
        public string collectionURI { get; set; }
        public List<Item4> items { get; set; }
    }

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
        public Series Series { get; set; }
        public List<Variant> Variants { get; set; }
        public List<Collection> Collections { get; set; }
        public List<CollectedIssue> CollectedIssues { get; set; }
        public List<Date> Dates { get; set; }
        public List<Price> Prices { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public List<Image> Images { get; set; }
        public Creators Creators { get; set; }
        public Characters Characters { get; set; }
        public Stories Stories { get; set; }
        public Events Events { get; set; }
    }
}
