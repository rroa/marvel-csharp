using System;
using System.Collections.Generic;

namespace Marvel.Api.Filters
{
    public class EventRequestFilter : BaseFilter
    {
        private readonly List<int> _creators;
        private readonly List<int> _characters;
        private readonly List<int> _series;
        private readonly List<int> _comics;         
        private readonly List<int> _stories;

        public EventRequestFilter()
        {
            _comics = new List<int>();
            _series = new List<int>();
            _creators = new List<int>();
            _characters = new List<int>();
            _stories = new List<int>();
        }

        public void AddComic(int id)
        {
            if (!_comics.Contains(id))
                _comics.Add(id);
        }

        public void AddCreator(int id)
        {
            if (!_creators.Contains(id))
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
