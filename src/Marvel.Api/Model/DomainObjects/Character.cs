using System.Collections.Generic;
using Marvel.Api.Model.Lists;

namespace Marvel.Api.Model.DomainObjects
{
    public class Character
    {
        /// <summary>
        /// The unique ID of the character resource.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the character.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A short bio or description of the character.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The date the resource was most recently modified.
        /// </summary>
        public string Modified { get; set; }

        /// <summary>
        /// The canonical URL identifier for this resource.
        /// </summary>
        public string ResourceURI { get; set; }

        /// <summary>
        /// A set of public web site URLs for the resource.
        /// </summary>
        public List<Url> Urls { get; set; }

        /// <summary>
        /// The representative image for this character.
        /// </summary>
        public Thumbnail Thumbnail { get; set; }

        /// <summary>
        /// A resource list containing comics which feature this character.
        /// </summary>
        public ComicList Comics { get; set; }

        /// <summary>
        /// A resource list of stories in which this character appears.
        /// </summary>
        public StoryList Stories { get; set; }

        /// <summary>
        /// A resource list of events in which this character appears.
        /// </summary>
        public EventList Events { get; set; }

        /// <summary>
        /// A resource list of series in which this character appears.
        /// </summary>
        public SeriesList Series { get; set; }
    }  
}
