using System;
using System.Collections.Generic;

namespace Marvel.Api.Filters
{
    public class StoryRequestFilter : BaseFilter
    {        
        private readonly List<int> _characters;
        private readonly List<int> _series;
        private readonly List<int> _comics;                 
        private readonly List<int> _creators;
        private readonly List<int> _events;

        public StoryRequestFilter()
        {
            _comics = new List<int>();
            _series = new List<int>();
            _creators = new List<int>();
            _characters = new List<int>();            
            _events = new List<int>();
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

        public void AddEvent(int id)
        {
            if (!_events.Contains(id))
                _events.Add(id);
        }  

        #region Properties
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
        #endregion
    }
}
