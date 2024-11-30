using System.Net.Http.Json;
using web_api.Models;

namespace web_api
{
    internal class Program
    {
        // initialize an HttpClient with a base address pointing to the GitHub API
        static readonly HttpClient client = new()
        {
            BaseAddress = new Uri("https://api.github.com/"), // sets this url as the base URL
            DefaultRequestHeaders = { { "User-Agent", "ConsoleApp" } }// Add a user agent header required by github api
        };

        static async Task Main()
        {

            try
            {
                Console.WriteLine("Fetching...");// inform user that data is being fetched
                var repos = await client.GetFromJsonAsync<Repository[]>("orgs/dotnet/repos");

                if (repos != null)// if resp is not null
                {
                    Console.Clear();
                    Console.WriteLine(repos);

                }

                // loop thru each repo obj and print its details to console.
                foreach (var repo in repos)
                {
                    // using string interpolation with a ternary to check data.
                    Console.WriteLine($"\n Name: {(string.IsNullOrWhiteSpace(repo.Name) ? "error: Not Found" : repo.Name.Trim())}");
                    Console.WriteLine($" Homepage: {(string.IsNullOrWhiteSpace(repo.Homepage) ? "error: Not Found" : repo.Homepage.Trim())}");
                    Console.WriteLine($" GitHub: {repo.GitHub}");
                    Console.WriteLine($" Description: {repo.Description}");
                    Console.WriteLine($" Watchers: {repo.Watchers}");
                    Console.WriteLine($" Last Push: {repo.LastPush}");
                    Console.WriteLine($"------------------------------------");
                }
            }
            catch (Exception ex)
            {
                // prints an error message to the console with details about the exception
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
