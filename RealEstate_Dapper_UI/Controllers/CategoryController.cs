using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
    public class CategoryController : Controller
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public CategoryController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responsemessage = await client.GetAsync("https://localhost:44350/api/Categories");
			if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
			{
				var jsondata = await responsemessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult NewAddCategory()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> NewAddCategory(CreateCategoryDto createCategoryDto)
		{
			var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk
			var jsonData = JsonConvert.SerializeObject(createCategoryDto);//Modelden gelen veriyi Json Türüne Çevirdik, Normal Veriyi Json Türüne Çevirmek için SerializeObject Kullanılır
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//İçeriğin dönüşümü için kullancaz(content,encoding,mediaType)
			var responseMessage = await client.PostAsync("https://localhost:44350/api/Categories", stringContent);
			if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> DeleteCategory(int CategoryId)
		{
			var client = _httpClientFactory.CreateClient();//İstemciyi Oluşturduk
			var responseMessage = await client.DeleteAsync($"https://localhost:44350/api/Categories?CategoryId={CategoryId}");
			if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
			{
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> GetCategory(int CategoryId)
		{
			var client = _httpClientFactory.CreateClient();
			var responsemessage = await client.GetAsync($"https://localhost:44350/api/Categories/{CategoryId}");
			if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
			{
				var jsondata = await responsemessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> GetCategory(UpdateCategoryDto updateCategoryDto)
		{
			var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk
			var jsonData = JsonConvert.SerializeObject(updateCategoryDto);//Modelden gelen veriyi Json Türüne Çevirdik
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//İçeriğin dönüşümü için kullancaz(content,encoding,mediaType)
			var responseMessage = await client.PutAsync("https://localhost:44350/api/Categories", stringContent);
			if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
