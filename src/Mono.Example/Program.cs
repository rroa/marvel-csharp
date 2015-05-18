using System;
using Marvel.Api;

namespace Mono.Example
{
    public class Program
    {
        const string publicKey = "YOUR PUBLIC KEY";
        const string privateKey = "YOUR PRIVATE KEY";
        public static void Main()
        {
            // Initialize the API client
            //
            var client = new MarvelRestClient(publicKey, privateKey);

            // First 20 characters
            //
            var response = client.FindCharacters();

            // Iterate through the results and print them out.
            //
            response.Data.Results.ForEach(c => Console.WriteLine($"{c.Name} : {c.Description}"));
            Console.ReadLine();
        }
    }
}
