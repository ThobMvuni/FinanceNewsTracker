﻿using FinanceNewsTracker.Models;
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
        public FinanceNews GetFinanceNews(int offset)
        {
            string apikey = _configuration.GetValue<string>("API_KEY");
            string baseURl = _configuration.GetValue<string>("API_URL");

            using (var client = new HttpClient()) { 
                   
                client.BaseAddress = new Uri(baseURl);

                var parameters = string.Format("?apikey={0}&offset={1}&date={2}&sort={3}", apikey, offset, "today", "desc");

                HttpResponseMessage response = client.GetAsync(parameters).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<FinanceNews>(result);

                } else
                {
                    return new FinanceNews()
                    {
                        Data = new List<NewsArticle>(),
                        Pagination = new Pagination()
                    };
                }
                

            }
        }
    }
}
