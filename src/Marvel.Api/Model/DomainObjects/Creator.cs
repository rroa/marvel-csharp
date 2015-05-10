using System.Collections.Generic;
using Marvel.Api.Model.Lists;

namespace Marvel.Api.Model.DomainObjects
{    
    public class Creator
    {
        #region Properties
        /// <summary>
        /// The unique ID of the creator resource.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The first name of the creator.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The middle name of the creator.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// The last name of the creator.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The suffix or honorific for the creator.
        /// </summary>
        public string Suffix { get; set; }

        /// <summary>
        /// The full name of the creator 
        /// (a space-separated concatenation of the above four fields).
        /// </summary>
        public string FullName { get; set; }

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
        /// The representative image for this creator.
        /// </summary>
        public Thumbnail Thumbnail { get; set; }

        /// <summary>
        /// A resource list containing the series which feature work by this creator.
        /// </summary>
        public SeriesList Series { get; set; }

        /// <summary>
        /// A resource list containing the stories which feature work by this creator.
        /// </summary>
        public StoryList Stories { get; set; }

        /// <summary>
        /// A resource list containing the comics which feature work by this creator.
        /// </summary>
        public ComicList Comics { get; set; }

        /// <summary>
        /// A resource list containing the events which feature work by this creator.
        /// </summary>
        public EventList Events { get; set; }
        #endregion
    }
}
