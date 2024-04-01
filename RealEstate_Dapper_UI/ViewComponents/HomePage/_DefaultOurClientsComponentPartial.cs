using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.TestimonialDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
	public class _DefaultOurClientsComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultOurClientsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:44350/api/Testimonial");
            if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsondata);
                return View(values);
            }
            return View();
        }
	}
}
