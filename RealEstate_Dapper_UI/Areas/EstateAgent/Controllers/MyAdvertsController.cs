using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using System.Net.Http;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class MyAdvertsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MyAdvertsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Home"] = "Ana Sayfa";
            TempData["Pages"] = "İlanlar";
            TempData["Starter"] = "Tüm İlanlarım";

            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync($"https://localhost:44350/api/Product/ProductAdvertsListByEmployeId/1");
            if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                return View(values);
            }
            return View();
        }
    }
}
