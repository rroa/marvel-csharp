namespace Marvel.Api
{
    public class ResultBase<T> where T : class, new()
    {
        public string Code { get; set; }
        public string Status { get; set; }
        public string Copyright { get; set; }
        public string AttributionText { get; set; }
        public string AttributionHtml { get; set; }
        public DataContainer<T> Data { get; set; }
        public string Etag { get; set; }
    }
}
