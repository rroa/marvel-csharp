using System;
using System.Collections.Generic;

namespace Marvel.Api.Filters
{
    public class CreatorRequestFilter : BaseFilter
    {
        private readonly List<int> _comics;
        private readonly List<int> _series;
        private readonly List<int> _events;
        private readonly List<int> _stories;

        public CreatorRequestFilter()
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
        /// Filter by creator first name (e.g. Brian).
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Filter by creator middle name (e.g. Michael).
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Filter by creator last name (e.g. Bendis).
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Filter by suffix or honorific (e.g. Jr., Sr.).
        /// </summary>
        public string Suffix { get; set; }

        /// <summary>
        /// Filter by creator names that match critera (e.g. B, St L).
        /// </summary>
        public string NameStartsWith { get; set; }

        /// <summary>
        /// Filter by creator first names that match critera (e.g. B, St L).
        /// </summary>
        public string FirstNameStartsWith { get; set; }

        /// <summary>
        /// Filter by creator middle names that match critera (e.g. Mi).
        /// </summary>
        public string MiddleNameStartsWith { get; set; }

        /// <summary>
        /// Filter by creator last names that match critera (e.g. Ben).
        /// </summary>
        public string LastNameStartsWith { get; set; }

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
