using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.EmployeeDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public EmployeeController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}


		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responsemessage = await client.GetAsync("https://localhost:44350/api/Employee");
			if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
			{
				var jsondata = await responsemessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult NewAddEmployee()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> NewAddEmployee(CreateEmployeeDto createEmployeeDto)
		{
			var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk
			var jsonData = JsonConvert.SerializeObject(createEmployeeDto);//Modelden gelen veriyi Json Türüne Çevirdik, Normal Veriyi Json Türüne Çevirmek için SerializeObject Kullanılır
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//İçeriğin dönüşümü için kullancaz(content,encoding,mediaType)
			var responseMessage = await client.PostAsync("https://localhost:44350/api/Employee", stringContent);
			if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> DeleteEmployee(int EmployeeId)
		{
			var client = _httpClientFactory.CreateClient();//İstemciyi Oluşturduk
			var responseMessage = await client.DeleteAsync($"https://localhost:44350/api/Employee?EmployeeId={EmployeeId}");
			if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
			{
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> GetEmployee(int EmployeeId)
		{
			var client = _httpClientFactory.CreateClient();
			var responsemessage = await client.GetAsync($"https://localhost:44350/api/Employee/{EmployeeId}");
			if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
			{
				var jsondata = await responsemessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateEmployeeDto>(jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> GetEmployee(UpdateEmployeeDto updateEmployeeDto)
		{
			var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk
			var jsonData = JsonConvert.SerializeObject(updateEmployeeDto);//Modelden gelen veriyi Json Türüne Çevirdik
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
