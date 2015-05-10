using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Marvel.Api.Filters
{
    public enum SeriesType
    {        
        [Description("collection")]
        Collection,

        [Description("one shot")]
        OneShot,

        [Description("limited")]
        Limited,

        [Description("ongoing")]
        OnGoing
    }

    [Flags]
    public enum ComicFormatType
    {
        [Description("comic")]
        Comic = 0x00,

        [Description("magazine")]
        Magazine = 0x01,

        [Description("trade paperback")]
        TradePaperback = 0x02,

        [Description("hardcover")]
        Hardcover = 0x04
    }

    public class SeriesRequestFilter : BaseFilter
    {
        private ComicFormatType _comicFormatType;
        private readonly List<int> _comics;
        private readonly List<int> _stories;
        private readonly List<int> _events;
        private readonly List<int> _creators;
        private readonly List<int> _characters;

        public SeriesRequestFilter()
        {
            _comics = new List<int>();
            _stories = new List<int>();
            _events = new List<int>();
            _creators = new List<int>();
            _characters = new List<int>();
        }

        public void ComicFormatType(ComicFormatType format)
        {
            if ((format & _comicFormatType) == 0)
                _comicFormatType |= format;
        }

        #region Properties
        /// <summary>
        /// Return only issues in series whose title matches the input.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Return only issues in series whose title starts with the input.
        /// </summary>
        public string TitleStartsWith { get; set; }

        /// <summary>
        /// Return only series matching the specified start year.
        /// </summary>
        public int? StartYear { get; set; }

        /// <summary>
        /// Return only comics which have been modified since the specified date.
        /// </summary>
        public DateTime? ModifiedSince { get; set; }

        /// <summary>
        /// Return only characters which appear in the specified comics 
        /// (accepts a comma-separated list of ids).
        /// </summary>
        public string Comics
        {
            get
            {
                if (_comics.Count == 0)
                    return string.Empty;

                return string.Join(",", _comics.ToArray());
            }
        }

        /// <summary>
        /// Return only series which contain the specified stories 
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
        /// Return only stories which take place during the specified events 
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
        /// Filter the series by publication frequency type.
        /// </summary>
        public SeriesType? SeriesType { get; set; }

        /// <summary>
        /// Order the result set by a field or fields
        /// </summary>
        public string Contains
        {
            get
            {
                var result = new List<string>();
                foreach (ComicFormatType format in Enum.GetValues(typeof(ComicFormatType)))
                {
                    if ((_comicFormatType & format) != 0)
                        result.Add(format.GetDescription());
                }

                if (result.Count == 0)
                    return string.Empty;

                return string.Join(",", result.ToArray());
            }
        }
        #endregion
    }
}
