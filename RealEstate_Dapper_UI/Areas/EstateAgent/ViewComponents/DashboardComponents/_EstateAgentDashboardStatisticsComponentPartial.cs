using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.ViewComponents.Dashboard
{
    public class _EstateAgentDashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public _EstateAgentDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            #region AllProductCount
            var responsemessage = await client.GetAsync("https://localhost:44350/api/EstateAgentDashboardStatistics/AllProductCount");
            if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                ViewBag.AllProductCount = jsondata;
            }
            #endregion

            #region ProductCountByEmployeeId
            var responsemessage1 = await client.GetAsync($"https://localhost:44350/api/EstateAgentDashboardStatistics/ProductCountByEmployeeId/{Convert.ToInt32(_loginService.GetUserId)}");
            if (responsemessage1.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata1 = await responsemessage1.Content.ReadAsStringAsync();
                ViewBag.ProductCountByEmployeeId = jsondata1;
            }
            #endregion

            #region ProductCountByStatusFalse
            var responsemessage2 = await client.GetAsync($"https://localhost:44350/api/EstateAgentDashboardStatistics/ProductCountByStatusFalse/{Convert.ToInt32(_loginService.GetUserId)}");
            if (responsemessage2.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata2 = await responsemessage2.Content.ReadAsStringAsync();
                ViewBag.ProductCountByStatusFalse = jsondata2;
            }
            #endregion

            #region ProductCountByStatusTrue
            var responsemessage3 = await client.GetAsync($"https://localhost:44350/api/EstateAgentDashboardStatistics/ProductCountByStatusTrue/{Convert.ToInt32(_loginService.GetUserId)}");
            if (responsemessage3.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata3 = await responsemessage3.Content.ReadAsStringAsync();
                ViewBag.ProductCountByStatusTrue = jsondata3;
            }
            #endregion

            return View();
        }
    }
}
