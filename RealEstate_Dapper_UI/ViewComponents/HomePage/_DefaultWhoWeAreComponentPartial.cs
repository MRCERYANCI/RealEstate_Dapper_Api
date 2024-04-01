using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultWhoWeAreComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

		public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
			var client = _httpClientFactory.CreateClient();
			var responsemessage = await client.GetAsync("https://localhost:44350/api/WhoWeAre");
			if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
			{
				var jsondata = await responsemessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultWhoWeAreDto>>(jsondata);
				ViewBag.Title = values.Select(x => x.WhoWeAreTitle).FirstOrDefault();
				ViewBag.SubTitle = values.Select(x => x.WhoWeAreSubTitle).FirstOrDefault();
				ViewBag.Description1 = values.Select(x => x.WhoWeAreDescription1).FirstOrDefault();
				ViewBag.Description2 = values.Select(x => x.WhoWeAreDescription2).FirstOrDefault();
			}
			return View();
		}
    }
}
