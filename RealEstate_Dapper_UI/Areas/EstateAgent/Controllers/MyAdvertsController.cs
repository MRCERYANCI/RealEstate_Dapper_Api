using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Services;
using System.Net.Http;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.Controllers
{
    [Authorize]
    [Area("EstateAgent")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class MyAdvertsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public MyAdvertsController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IActionResult> ActiveAdverts()
        {
            TempData["Home"] = "Ana Sayfa";
            TempData["Pages"] = "İlanlar";
            TempData["Starter"] = "Tüm İlanlarım";

            var token = User.Claims.FirstOrDefault(x => x.Type == "realestatetoken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                var responsemessage = await client.GetAsync($"https://localhost:44350/api/Product/ProductAdvertsListByTrueEmployeId/{Convert.ToInt32(_loginService.GetUserId)}");
                if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
                {
                    var jsondata = await responsemessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                    return View(values);
                }
            }

            return View();
        }

        public async Task<IActionResult> PasiveAdverts()
        {
            TempData["Home"] = "Ana Sayfa";
            TempData["Pages"] = "İlanlar";
            TempData["Starter"] = "Pasif İlanlarım";

            var token = User.Claims.FirstOrDefault(x => x.Type == "realestatetoken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                var responsemessage = await client.GetAsync($"https://localhost:44350/api/Product/ProductAdvertsListByFalseEmployeId/{Convert.ToInt32(_loginService.GetUserId)}");
                if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
                {
                    var jsondata = await responsemessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                    return View(values);
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateAdverts()
        {
            TempData["Home"] = "Ana Sayfa";
            TempData["Pages"] = "İlanlar";
            TempData["Starter"] = "Yeni İlan Ekle";


            return View();
        }
    }
}
