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
### Event
### Creator
### Series
### Story
    
