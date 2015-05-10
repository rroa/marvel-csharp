using System.Collections.Generic;
using Marvel.Api.Model.Lists;
using Marvel.Api.Model.Summaries;

namespace Marvel.Api.Model.DomainObjects
{
    public class Event
    {
        #region Properties
        /// <summary>
        /// The unique ID of the event resource.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title of the event.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// A description of the event.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The canonical URL identifier for this resource.
        /// </summary>
        public string ResourceURI { get; set; }

        /// <summary>
        /// A set of public web site URLs for the event.
        /// </summary>
        public List<Url> Urls { get; set; }

        /// <summary>
        /// The date the resource was most recently modified.
        /// </summary>
        public string Modified { get; set; }

        /// <summary>
        /// The date of publication of the first issue in this event.
        /// </summary>
        public string Start { get; set; }

        /// <summary>
        /// The date of publication of the last issue in this event.
        /// </summary>
        public string End { get; set; }

        /// <summary>
        /// The representative image for this event.
        /// </summary>
        public Thumbnail Thumbnail { get; set; }

        /// <summary>
        /// A resource list containing the comics in this event.
        /// </summary>
        public ComicList Comics { get; set; }
        
        /// <summary>
        /// A resource list containing the stories in this event.
        /// </summary>
        public StoryList Stories { get; set; }

        /// <summary>
        /// A resource list containing the series in this event.
        /// </summary>
        public SeriesList Series { get; set; }

        /// <summary>
        /// A resource list containing the characters which appear in this event.
        /// </summary>
        public CharacterList Characters { get; set; }

        /// <summary>
        /// A resource list containing creators whose work appears in this event.
        /// </summary>
        public CreatorList Creators { get; set; }

        /// <summary>
        /// A summary representation of the event which follows this event.
        /// </summary>
        public EventSummary Next { get; set; }

        /// <summary>
        /// A summary representation of the event which preceded this event.
        /// </summary>
        public EventSummary Previous { get; set; }
        #endregion
    }    
}
