using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.ViewComponents.PropertySingle
{
    public class _PropertyPopularPoastComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _PropertyPopularPoastComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync($"https://localhost:44350/api/Product/ResultLast3Product/{id}");
            if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast3ProductDto>>(jsondata);
                return View(values);
            }
            return View();
        }
    }
}
