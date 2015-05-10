using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Marvel.Api.Filters
{
    public enum FormatType
    {
        [Description("comic")]
        Comic,

        [Description("collection")]
        Collection
    }

    public enum DateDescriptor
    {
        [Description("lastWeek")]
        LastWeek,

        [Description("thisWeek")]
        ThisWeek,

        [Description("nextWeek")]
        NextWeek,

        [Description("thisMonth")]
        ThisMonth
    }
    public enum Format
    {
        [Description("comic")]
        Comic,

        [Description("magazine")]
        Magazine,

        [Description("trade paperback")]
        TradePaperback,

        [Description("hardcover")]
        Hardcover,

        [Description("digest")]
        Digest,

        [Description("graphic novel")]
        GraphicNovel,

        [Description("digital comic")]
        DigitalComic,

        [Description("infinite comic")]
        InfiniteComic
    }

    public class ComicRequestFilter : BaseFilter
    {        
        private readonly List<int> _creators;
        private readonly List<int> _characters;
        private readonly List<int> _series;
        private readonly List<int> _events;
        private readonly List<int> _stories;
        private readonly List<int> _sharedAppearances;
        private readonly List<int> _collaborators;
        private readonly List<string> _dates;

        public ComicRequestFilter()
        {
            _creators= new List<int>();
            _characters= new List<int>();
            _series= new List<int>();
            _events= new List<int>();
            _stories= new List<int>();
            _sharedAppearances = new List<int>();
            _collaborators = new List<int>();
            _dates = new List<string>(2);
        }

        public void AddCreator(int id)
        {
            if(!_creators.Contains(id))
                _creators.Add(id);
        }

        public void AddCharacter(int id)
        {
            if (!_characters.Contains(id))
                _characters.Add(id);
        }

        public void AddSeries(int id)
        {
            if (!_series.Contains(id))
                _series.Add(id);
        }

        public void AddEvent(int id)
        {
            if (!_events.Contains(id))
                _events.Add(id);
        }

        public void AddStory(int id)
        {
            if (!_stories.Contains(id))
                _stories.Add(id);
        }

        public void AddAppearance(int id)
        {
            if (!_sharedAppearances.Contains(id))
                _sharedAppearances.Add(id);
        }

        public void AddCollaborator(int id)
        {
            if (!_collaborators.Contains(id))
                _collaborators.Add(id);
        }

        public void AddDateToRange(DateTime date)
        {
            if (_dates.Count < 2 && !_dates.Contains(date.ToString("yyyy-MM-dd")))
                _dates.Add(date.ToString("yyyy-MM-dd"));
        }

        #region Properties
        /// <summary>
        /// Filter by the issue format (e.g. comic, digital comic, hardcover).
        /// </summary>
        public Format? Format { get; set; }

        /// <summary>
        /// Filter by the issue format type (comic or collection).
        /// </summary>
        public FormatType? FormatType { get; set; }

        /// <summary>
        /// Exclude variants (alternate covers, secondary printings, director's cuts, etc.) 
        /// from the result set.
        /// </summary>
        public bool? NoVariants { get; set; }

        /// <summary>
        /// Return comics within a predefined date range.
        /// </summary>
        public DateDescriptor? DateDescriptor { get; set; }

        /// <summary>
        /// Return comics within a predefined date range. 
        /// Dates must be specified as date1,date2 (e.g. 2013-01-01,2013-01-02). 
        /// Dates are preferably formatted as YYYY-MM-DD but may be sent as any 
        /// common date format.
        /// </summary>
        public string DateRange
        {
            get
            {
                if (_dates.Count == 0)
                    return string.Empty;

                return string.Join(",", _dates.ToArray());
            }
        }

        /// <summary>
        /// Return only issues in series whose title matches the input.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Return only issues in series whose title starts with the input.
        /// </summary>

        public string TitleStartsWith { get; set; }

        /// <summary>
        /// Return only issues in series whose start year matches the input.
        /// </summary>
        public int? StartYear { get; set; }

        /// <summary>
        /// Return only issues in series whose issue number matches the input.
        /// </summary>
        public int? IssueNumber { get; set; }

        /// <summary>
        /// Filter by diamond code.
        /// </summary>
        public string DiamondCode { get; set; }

        /// <summary>
        /// Filter by digital comic id.
        /// </summary>
        public int? DigitalId {get;set;}

        /// <summary>
        /// Filter by UPC.
        /// </summary>
        public string UPC { get; set; }

        /// <summary>
        /// Filter by ISBN.
        /// </summary>
        public string ISBN { get; set; }

        /// <summary>
        /// Filter by EAN.
        /// </summary>
        public string EAN { get; set; }

        /// <summary>
        /// Filter by ISSN.
        /// </summary>
        public string ISSN { get; set; }

        /// <summary>
        /// Include only results which are available digitally.
        /// </summary>
        public bool? HasDigitalIssue { get; set; }

        /// <summary>
        /// Return only comics which have been modified since the specified date.
        /// </summary>
        public DateTime? ModifiedSince { get; set; }

        /// <summary>
        /// Return only comics which feature work by the specified creators 
        /// (accepts a comma-separated list of ids).
        /// </summary>
        public string Creators
        {
            get
            {
                if (_creators.Count == 0)
                    return string.Empty;

                return string.Join(",", _creators.ToArray());
            }
        }

        /// <summary>
        /// Return only comics which feature the specified characters 
        /// (accepts a comma-separated list of ids).
        /// </summary>
        public string Characters
        {
            get
            {
                if (_characters.Count == 0)
                    return string.Empty;

                return string.Join(",", _characters.ToArray());
            }
        }

        /// <summary>
        /// Return only comics which are part of the specified series 
        /// (accepts a comma-separated list of ids).
        /// </summary>
        public string Series
        {
            get
            {
                if (_series.Count == 0)
                    return string.Empty;

                return string.Join(",", _series.ToArray());
            }
        }

        /// <summary>
        /// Return only comics which take place in the specified events 
        /// (accepts a comma-separated list of ids).
        /// </summary>
        public string Events
        {
            get
            {
                if (_events.Count == 0)
                    return string.Empty;

                return string.Join(",", _events.ToArray());
            }
        }

        /// <summary>
        /// Return only comics which contain the specified stories 
        /// (accepts a comma-separated list of ids).
        /// </summary>
        public string Stories
        {
            get
            {
                if (_stories.Count == 0)
                    return string.Empty;

                return string.Join(",", _stories.ToArray());
            }
        }

        /// <summary>
        /// Return only comics in which the specified characters appear together 
        /// (for example in which BOTH Spider-Man and Wolverine appear). 
        /// Accepts a comma-separated list of ids.
        /// </summary>
        public string SharedAppearances
        {
            get
            {
                if (_sharedAppearances.Count == 0)
                    return string.Empty;

                return string.Join(",", _sharedAppearances.ToArray());
            }
        }

        /// <summary>
        /// Return only comics in which the specified creators worked together 
        /// (for example in which BOTH Stan Lee and Jack Kirby did work). 
        /// Accepts a comma-separated list of ids.
        /// </summary>
        public string Collaborators
        {
            get
            {
                if (_collaborators.Count == 0)
                    return string.Empty;

                return string.Join(",", _collaborators.ToArray());
            }
        }
        #endregion
    }
}
