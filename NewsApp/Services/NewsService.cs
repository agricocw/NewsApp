using System.Net.Http;
using System.Text.Json;
using NewsApp.Models;

namespace NewsApp.Services
{
    public class NewsService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<List<NewsArticle>> GetNewsByCategoryAsync(string category)
        {
            string apiKey = "378e6e14dbfb10e5f17335840933f6e2";
            string url = $"https://gnews.io/api/v4/top-headlines?category={category}&lang=en&token={apiKey}";

            var response = await _httpClient.GetStringAsync(url);

            var jsonDoc = JsonDocument.Parse(response);
            var articles = new List<NewsArticle>();

            foreach (var item in jsonDoc.RootElement.GetProperty("articles").EnumerateArray())
            {
                articles.Add(new NewsArticle
                {
                    Title = item.GetProperty("title").GetString(),
                    Content = item.GetProperty("content").GetString(),
                    Image = item.GetProperty("image").GetString()
                });
            }

            return articles;
        }
    }
}
