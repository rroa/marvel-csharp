using System.Collections.Generic;

namespace Marvel.Api.Model
{
    public class Url
    {
        public string Type { get; set; }
        public string Uri { get; set; }
    }

    public class Thumbnail
    {
        public string Path { get; set; }
        public string Extension { get; set; }
    }

    public class Comics
    {
        public string Available { get; set; }
        public string Returned { get; set; }
        public string CollectionUri { get; set; }
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        public string ResourceUri { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class Stories
    {
        public string Available { get; set; }
        public string Returned { get; set; }
        public string CollectionUri { get; set; }
        public List<Item> Items { get; set; }
    }

    public class Events
    {
        public string Available { get; set; }
        public string Returned { get; set; }
        public string CollectionUri { get; set; }
        public List<Item> Items { get; set; }
    }
    public class Series
    {
        public string Available { get; set; }
        public string Returned { get; set; }
        public string CollectionUri { get; set; }
        public List<Item> Items { get; set; }
    }

    public class Result
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Modified { get; set; }
        public string ResourceUri { get; set; }
        public List<Url> Urls { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public Comics Comics { get; set; }
        public Stories Stories { get; set; }
        public Events Events { get; set; }
        public Series Series { get; set; }
    }

    public class DataContainer
    {
        public string Offset { get; set; }
        public string Limit { get; set; }
        public string Total { get; set; }
        public string Count { get; set; }
        public List<Result> Results { get; set; }
    }

    public class DataWrapper
    {
        public string Code { get; set; }
        public string Status { get; set; }
        public string Copyright { get; set; }
        public string AttributionText { get; set; }
        public string AttributionHtml { get; set; }
        public DataContainer Data { get; set; }
        public string Etag { get; set; }
    }
}
