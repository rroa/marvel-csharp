# marvel-csharp [![NuGet version](https://badge.fury.io/nu/Marvel.Api.svg)](http://badge.fury.io/nu/Marvel.Api)
Official Marvel API C# wrapper

## Installation
Head over to [developer.marvel.com](http://developer.marvel.com) and sign up/in to get your API keys.

### Nuget
Use [NuGet](https://www.nuget.org/) to fetch and install the library for you. You can see the project's NuGet page [here]((https://www.nuget.org/packages/Marvel.Api/)). (This is the recommended method for install)

    Install-Package Marvel.Api
 
### Quick start
Initialize the API client

    const string publicKey = "YOUR PUBLIC KEY";
    const string privateKey = "YOUR PRIVATE KEY";
    
    // Initialize the API client
    //
    var client = new MarvelRestClient(publicKey, privateKey);
  
    // First 20 characters
    //
    var response = client.FindCharacters();
    
    // Iterate through the results
    //
    foreach (var character in response.Data.Results)
    {
        // Do something with the character info
        string name = character.Name;
    }
    
### Filtered search
Create a entity filter object and set the desired search values.

    // Client definition
    var client = new MarvelRestClient(apiKey, privateKey);
    
    // Filter definition
    var filter = new CharacterRequestFilter();
    filter.Name = "3-D Man";
    filter.OrderBy(OrderResult.NameAscending);
    filter.ModifiedSince = new DateTime(2012,12,12);
    
    filter.AtComic(21366);
    filter.AtComic(24571);
    
    // Perform Search
    var response = client.GetCharacters(filter);
    
    // Iterate through the results
    //
    foreach (var character in response.Data.Results)
    {
        // Do something with the character info
        string name = character.Name;
    }
    
## API

The official API is broken into a given set of entities
### Character
    // Fetches lists of comic characters with optional filters.
    FindCharacters (CharacterRequestFilter filter=default(CharacterRequestFilter))
    
    // This method fetches a single character resource. It is the canonical
    // URI for any character resource provided by the API.
    FindCharacter (string characterId)
    
    // Fetches lists of comics containing a specific character, 
    // with optional filters.
    FindCharacterComics (string characterId, 
                         ComicRequestFilter filter=default(ComicRequestFilter))
    
    // Fetches lists of events in which a specific character appears, 
    // with optional filters.
    FindCharacterEvents (string characterId, 
                         EventRequestFilter filter=default(EventRequestFilter))
    
    // Fetches lists of comic series in which a specific character appears,
    // with optional filters.
    FindCharacterSeries (string characterId, 
                         SeriesRequestFilter filter=default(SeriesRequestFilter)) 	
    
    // Fetches lists of comic stories featuring a specific character 
    // with optional filters.
    FindCharacterStories (string characterId, 
                          StoryRequestFilter filter=default(StoryRequestFilter))
    
### Comic
    // Fetches lists of comics with optional filters.
    FindComics (ComicRequestFilter filter=default(ComicRequestFilter))
    
    // This method fetches a single comic resource. 
    // It is the canonical URI for any comic resource provided by the API.
    FindComic (string comicId)
    
    // Fetches lists of comic creators whose work appears in a specific comic, 
    // with optional filters.
    FindComicCreators (string comicId, 
                       CreatorRequestFilter filter=default(CreatorRequestFilter))
    
    // Fetches lists of characters which appear in a specific comic 
    // with optional filters.
    FindComicCharacters (string comicId, 
                         CharacterRequestFilter filter=default(CharacterRequestFilter))
    
    // Fetches lists of events in which a specific comic appears, with optional filters.
    FindComicEvents (string comicId, 
                     EventRequestFilter filter=default(EventRequestFilter))
 	
 	// Fetches lists of comic stories in a specific comic issue, 
 	// with optional filters.
 	FindComicStories (string comicId, 
 	                  StoryRequestFilter filter=default(StoryRequestFilter))

### Creator
    // Fetches lists of comic creators with optional filters.
    FindCreators (CreatorRequestFilter filter=default(CreatorRequestFilter))
    
    // This method fetches a single creator resource. 
    // It is the canonical URI for any creator resource provided by the API.
    FindCreator (string creatorId)
    
    // Fetches lists of comics in which the work of a specific creator appears, 
    // with optional filters.
    FindCreatorComics (string creatorId, 
                       ComicRequestFilter filter=default(ComicRequestFilter))
 	
 	// Fetches lists of events featuring the work of a specific creator 
 	// with optional filters.
 	FindCreatorEvents (string creatorId, 
 	                   EventRequestFilter filter=default(EventRequestFilter))
 	
 	// Fetches lists of comic series in which a specific creator's work appears, 
 	// with optional filters.
 	FindCreatorSeries (string creatorId, 
 	                   SeriesRequestFilter filter=default(SeriesRequestFilter))
 	
 	// Fetches lists of comic stories by a specific creator with optional filters.
 	FindCreatorStories (string creatorId, 
 	                    StoryRequestFilter filter=default(StoryRequestFilter))
 	
### Event
    // Fetches lists of events with optional filters.
    FindEvents (EventRequestFilter filter=default(EventRequestFilter))
    
    // This method fetches a single event resource. 
    // It is the canonical URI for any event resource provided by the API.
    FindEvent (string eventId)
 	
 	// Fetches lists of characters which appear in a specific event, 
 	// with optional filters.
 	FindEventCharacters (string eventId, 
 	                     CharacterRequestFilter filter=default(CharacterRequestFilter))
 	
 	// Fetches lists of comics which take place during a specific event, 
 	// with optional filters.
 	FindEventComics (string eventId, 
 	                 ComicRequestFilter filter=default(ComicRequestFilter))
 	
 	// Fetches lists of comic creators whose work appears in a specific event, 
 	// with optional filters.
 	FindEventCreators (string eventId, 
 	                   CreatorRequestFilter filter=default(CreatorRequestFilter))
 	
 	// Fetches lists of comic series in which a specific event takes place, 
 	// with optional filters.
 	FindEventSeries (string eventId, 
 	                 SeriesRequestFilter filter=default(SeriesRequestFilter))
 	
 	// Fetches lists of comic stories from a specific event, with optional filters.
 	FindEventStories (string eventId, 
 	                  StoryRequestFilter filter=default(StoryRequestFilter))
 	
### Series
    // Fetches lists of comic series with optional filters.
    FindSeries (SeriesRequestFilter filter=default(SeriesRequestFilter))
 	
 	// This method fetches a single comic series resource. 
 	// It is the canonical URI for any comic series resource provided by the API.
 	FindSeries (string seriesId)
 	
 	// Fetches lists of characters which appear in specific series, 
 	// with optional filters.
 	FindSeriesCharacters (string seriesId, 
 	                      CharacterRequestFilter filter=default(CharacterRequestFilter))
 	
 	// Fetches lists of comics which are published as part of a specific series, with optional filters.
 	FindSeriesComics (string seriesId, 
 	                  ComicRequestFilter filter=default(ComicRequestFilter))
 	
 	// Fetches lists of comic creators whose work appears in a specific series, 
 	// with optional filters.
 	FindSeriesCreators (string seriesId, 
 	                    CreatorRequestFilter filter=default(CreatorRequestFilter))
 	
 	// Fetches lists of events which occur in a specific series, with optional filters.
 	FindSeriesEvents (string seriesId, 
 	                  EventRequestFilter filter=default(EventRequestFilter))
 	
 	// Fetches lists of comic stories from a specific series with optional filters.
 	FindSeriesStories (string seriesId, 
 	                   StoryRequestFilter filter=default(StoryRequestFilter))
 	
### Story
    // Fetches lists of comic stories with optional filters.
    FindStories (StoryRequestFilter filter=default(StoryRequestFilter))
    
    // This method fetches a single comic story resource. 
    // It is the canonical URI for any comic story resource provided by the API.
    FindStory (string storyId)
 	
 	// Fetches lists of comic characters appearing in a single story, 
 	// with optional filters.
 	FindStoryCharacters (string storyId, 
 	                     CharacterRequestFilter filter=default(CharacterRequestFilter))
 	
 	// Fetches lists of comics in which a specific story appears, 
 	// with optional filters.
 	FindStoryComics (string storyId, 
 	                 ComicRequestFilter filter=default(ComicRequestFilter))
 	
 	// Fetches lists of comic creators whose work appears in a specific story, 
 	// with optional filters.
 	FindStoryCreators (string storyId, 
 	                   CreatorRequestFilter filter=default(CreatorRequestFilter))
 	
 	// Fetches lists of events in which a specific story appears, 
 	// with optional filters.
 	FindStoryEvents (string storyId, 
 	                 EventRequestFilter filter=default(EventRequestFilter))
 	
 	// Fetches lists of comic series in which the specified story takes place.
 	FindStorySeries (string storyId, 
 	                 SeriesRequestFilter filter=default(SeriesRequestFilter))
 	
