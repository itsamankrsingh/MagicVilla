using MagicVillaWeb.Interfaces;
using MagicVillaWeb.Models;

namespace MagicVillaWeb.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse response { get; set; }
        public IHttpClientFactory httpClient { get; set; }
        public BaseService(IHttpClientFactory httpClient)
        {
            this.response = new();
            this.httpClient = httpClient;
        }

        public Task<T> SendAsync<T>(APIRequest request)
        {
            try
            {
                var client = httpClient.CreateClient("MagicAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(request.Url);
                if (request.Data != null)
                {
                    message.Content = new StringContent(JsonConvert)
                }
            }
            catch (Exception ex) { }
        }
    }
}
