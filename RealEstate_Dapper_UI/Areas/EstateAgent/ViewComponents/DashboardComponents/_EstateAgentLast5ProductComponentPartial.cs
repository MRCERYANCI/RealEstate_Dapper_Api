using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.EstateAgentDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.ViewComponents.DashboardComponents
{
    public class _EstateAgentLast5ProductComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public _EstateAgentLast5ProductComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync($"https://localhost:44350/api/EstateAgentLastProducts/GetLast5Product?id={Convert.ToInt32(_loginService.GetUserId)}");
            if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast5ProductWithCategoryDto>>(jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                return View(values);
            }
            return View();
        }
    }
}
