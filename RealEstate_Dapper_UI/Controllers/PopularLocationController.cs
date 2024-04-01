using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.PopularLocationDtos;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PopularLocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PopularLocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:44350/api/PopularLocation");
            if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPopularLocationDto>>(jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult NewAddPopularLocation()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> NewAddPopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk
            var jsonData = JsonConvert.SerializeObject(createPopularLocationDto);//Modelden gelen veriyi Json Türüne Çevirdik, Normal Veriyi Json Türüne Çevirmek için SerializeObject Kullanılır
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//İçeriğin dönüşümü için kullancaz(content,encoding,mediaType)
            var responseMessage = await client.PostAsync("https://localhost:44350/api/PopularLocation", stringContent);
            if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeletePopularLocation(int PopularLocationId)
        {
            var client = _httpClientFactory.CreateClient();//İstemciyi Oluşturduk
            var responseMessage = await client.DeleteAsync($"https://localhost:44350/api/PopularLocation?PopularLocationId={PopularLocationId}");
            if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetPopularLocation(int PopularLocationId)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync($"https://localhost:44350/api/PopularLocation/{PopularLocationId}");
            if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdatePopularLocationDto>(jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetPopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk
            var jsonData = JsonConvert.SerializeObject(updatePopularLocationDto);//Modelden gelen veriyi Json Türüne Çevirdik
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//İçeriğin dönüşümü için kullancaz(content,encoding,mediaType)
            var responseMessage = await client.PutAsync("https://localhost:44350/api/PopularLocation", stringContent);
            if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
