using Newtonsoft.Json;

namespace FinanceNewsTracker.Models
{
    public class NewsArticle
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("tickers")]
        public List<string> Tickers { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("published_at")]
        public DateTime PublishedAt { get; set; }
    }
}
