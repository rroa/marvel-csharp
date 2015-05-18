namespace Marvel.Api
{
    //TODO: Importan documentation for this class missing, source http://developer.marvel.com/documentation/apiresults
    public class ResultBase<T> where T : class, new()
    {
        //TODO: this would be better as int like in the official documentation
        public string Code { get; set; }
        public string Status { get; set; }
        public string Copyright { get; set; }
        public string AttributionText { get; set; }
        public string AttributionHtml { get; set; }
        public DataContainer<T> Data { get; set; }
        public string Etag { get; set; }
    }
}
