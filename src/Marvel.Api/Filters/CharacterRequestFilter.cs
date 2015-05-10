using System;
using System.Collections.Generic;

namespace Marvel.Api.Filters
{    
    public class CharacterRequestFilter : BaseFilter
    {
        private readonly List<int> _comics;
        private readonly List<int> _series;
        private readonly List<int> _events;
        private readonly List<int> _stories;     

        public CharacterRequestFilter()
        {
            _comics = new List<int>();
            _series = new List<int>();
            _events = new List<int>();
            _stories = new List<int>();
        }

        public void AddComic(int id)
        {
            if (!_comics.Contains(id))
                _comics.Add(id);
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

        #region Properties
        /// <summary>
        /// Return only characters matching the specified full name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Return characters with names that begin with the specified string (e.g. Sp).
        /// </summary>
        public string NameStartsWith { get; set; }

        /// <summary>
        /// Return only characters which have been modified since the specified date.
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
        /// Return only characters which appear the specified series 
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
        /// Return only characters which appear in the specified events 
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
        /// Return only characters which appear the specified stories 
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
        #endregion
    }
}
