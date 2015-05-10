using Marvel.Api.Model.Lists;
using Marvel.Api.Model.Summaries;

namespace Marvel.Api.Model.DomainObjects
{      
    public class Story
    {
        #region Properties
        /// <summary>
        /// The unique ID of the story resource.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The story title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// A short description of the story.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The canonical URL identifier for this resource.
        /// </summary>
        public string ResourceURI { get; set; }

        /// <summary>
        /// The story type e.g. interior story, cover, text story.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The date the resource was most recently modified.
        /// </summary>
        public string Modified { get; set; }

        /// <summary>
        /// The representative image for this story.
        /// </summary>
        public Thumbnail Thumbnail { get; set; }

        /// <summary>
        /// A resource list containing comics in which this story takes place.
        /// </summary>
        public ComicList Comics { get; set; }

        /// <summary>
        /// A resource list containing series in which this story appears.
        /// </summary>
        public SeriesList Series { get; set; }

        /// <summary>
        /// A resource list of the events in which this story appears.
        /// </summary>
        public EventList Events { get; set; }

        /// <summary>
        /// A resource list of characters which appear in this story.
        /// </summary>
        public CharacterList Characters { get; set; }

        /// <summary>
        /// A resource list of creators who worked on this story.
        /// </summary>
        public CreatorList Creators { get; set; }

        /// <summary>
        /// A summary representation of the issue in which this story was originally published.
        /// </summary>
        public StorySummary OriginalIssue { get; set; }
        #endregion
    }
}
