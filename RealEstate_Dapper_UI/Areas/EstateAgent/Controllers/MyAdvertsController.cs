using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Services;
using System.Net.Http;
using System.Text;

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

            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:44350/api/Categories");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsondata);

                List<SelectListItem> CategoryList = (from x in values.ToList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.CategoryName.ToString(),
                                                         Value = x.CategoryId.ToString()
                                                     }).ToList();

                ViewBag.CategoryList = CategoryList;
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateAdverts(CreateProductDto createProductDto)
        {
            if (createProductDto.CoverImage != null)
            {
                createProductDto.Status = true;
                createProductDto.DealOfTheDay = false;
                createProductDto.ProductDescription = "deneme";
                createProductDto.EmployeeID = Convert.ToInt32(_loginService.GetUserId);
                var newImageName = Guid.NewGuid() + ".webp";
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/ProductImages/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                createProductDto.CoverImage.CopyTo(stream);
                createProductDto.ProductCoverImage = "/Images/ProductImages/" + newImageName;

                var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk
                var jsonData = JsonConvert.SerializeObject(createProductDto);//Modelden gelen veriyi Json Türüne Çevirdik, Normal Veriyi Json Türüne Çevirmek için SerializeObject Kullanılır
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//İçeriğin dönüşümü için kullancaz(content,encoding,mediaType)
                var responseMessage = await client.PostAsync("https://localhost:44350/api/Product", stringContent);
                if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
                {
                    return RedirectToAction("ActiveAdverts");
                }
            }
            return RedirectToAction("CreateAdverts");
        }
    }
}
