using Microsoft.AspNetCore.SignalR;

namespace RealEstate_Dapper_Api.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignalRHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task SendCategoryCount()
        {
            var client = _httpClientFactory.CreateClient();


            var responsemessage5 = await client.GetAsync("https://localhost:44350/api/Statistics/CategoryCount");
            if (responsemessage5.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata5 = await responsemessage5.Content.ReadAsStringAsync();
                await Clients.All.SendAsync("ReceiverCategoryCount",jsondata5);
            }

        }
    }
}
