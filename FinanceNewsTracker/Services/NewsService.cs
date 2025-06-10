using FinanceNewsTracker.Models;
using Newtonsoft.Json;

namespace FinanceNewsTracker.Services
{
    public class NewsService : INewsService
    {

       private readonly IConfiguration _configuration;
        
        public NewsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<FinanceNews> GetFinanceNewsAsync(int offset)
        {
            var apikey = _configuration.GetValue<string>("API_KEY");
            var baseURl = _configuration.GetValue<string>("API_URL");

            if (string.IsNullOrEmpty(apikey) || string.IsNullOrEmpty(baseURl))
            {
                throw new InvalidOperationException("API configuration is missing");
            }

            string completeUrl = $"{baseURl}?apikey={apikey}&offset={offset}&categories=finance,business&sort=desc&limit=10";
            Console.WriteLine($"Fetching news from: {completeUrl}");
            
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(completeUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"API Response: {content}");
                        var news = JsonConvert.DeserializeObject<FinanceNews>(content);
                        // Log successful fetch
                        Console.WriteLine($"Successfully fetched {news?.Data?.Count ?? 0} news articles");
                        return news;
                    }
                    else
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        throw new Exception($"API request failed with status code: {response.StatusCode}. Response: {errorContent}");
                    }
                }
                catch (Exception ex)
                {
                    // Log the error with more details
                    Console.WriteLine($"Error fetching news: {ex.Message}");
                    Console.WriteLine($"Stack trace: {ex.StackTrace}");
                    throw;
                }
            }
        }
    }
}
