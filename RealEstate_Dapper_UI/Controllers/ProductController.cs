using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
	public class ProductController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ProductController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responsemessage = await client.GetAsync("https://localhost:44350/api/Product/ProductListWithCategory");
			if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
			{
				var jsondata = await responsemessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> NewAddProduct()
		{
			var client = _httpClientFactory.CreateClient();
			var responsemessage = await client.GetAsync("https://localhost:44350/api/Categories");
			if(responsemessage.IsSuccessStatusCode)
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
		public async Task<IActionResult> NewAddProduct(CreateProductDto createProductDto)
		{
			var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk
			var jsonData = JsonConvert.SerializeObject(createProductDto);//Modelden gelen veriyi Json Türüne Çevirdik, Normal Veriyi Json Türüne Çevirmek için SerializeObject Kullanılır
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//İçeriğin dönüşümü için kullancaz(content,encoding,mediaType)
			var responseMessage = await client.PostAsync("https://localhost:44350/api/Product", stringContent);
			if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> ProductDealOfTheDayStatusChangeTo(int ProductId, bool ProductStatus)
		{
			var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk					
			var responseMessage = await client.GetAsync($"https://localhost:44350/api/Product/ProductDealOfTheDayStatusChangeTo?ProductId={ProductId}&ProductStatus={ProductStatus}");
			if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
