using System.Collections.Generic;
using Marvel.Api.Model.Lists;
using Marvel.Api.Model.Summaries;

namespace Marvel.Api.Model.DomainObjects
{
    public class Series
    {
        #region Properties
        /// <summary>
        /// The unique ID of the series resource.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The canonical title of the series.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// A description of the series.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The canonical URL identifier for this resource.
        /// </summary>
        public string ResourceURI { get; set; }

        /// <summary>
        /// A set of public web site URLs for the resource.
        /// </summary>
        public List<Url> Urls { get; set; }

        /// <summary>
        /// The first year of publication for the series.
        /// </summary>
        public string StartYear { get; set; }

        /// <summary>
        /// The last year of publication for the series (conventionally, 2099 for ongoing series) .,
        /// </summary>
        public string EndYear { get; set; }

        /// <summary>
        /// The age-appropriateness rating for the series.,
        /// </summary>
        public string Rating { get; set; }

        /// <summary>
        /// The date the resource was most recently modified.
        /// </summary>
        public string Modified { get; set; }

        /// <summary>
        /// The representative image for this series.
        /// </summary>
        public Thumbnail Thumbnail { get; set; }

        /// <summary>
        /// A resource list containing comics in this series.
        /// </summary>
        public ComicList Comics { get; set; }

        /// <summary>
        /// A resource list containing stories which occur in comics in this series.
        /// </summary>
        public StoryList Stories { get; set; }

        /// <summary>
        /// A resource list containing events which take place in comics in this series.
        /// </summary>
        public EventList Events { get; set; }

        /// <summary>
        /// A resource list containing characters which appear in comics in this series.
        /// </summary>
        public CharacterList Characters { get; set; }

        /// <summary>
        /// A resource list of creators whose work appears in comics in this series.
        /// </summary>
        public CreatorList Creators { get; set; }

        /// <summary>
        /// A summary representation of the series which follows this series.
        /// </summary>
        public SeriesSummary Next { get; set; }

        /// <summary>
        /// A summary representation of the series which preceded this series.
        /// </summary>
        public SeriesSummary Previous { get; set; }
        #endregion
    }    
}
