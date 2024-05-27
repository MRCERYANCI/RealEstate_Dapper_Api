using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardStatisticsComponenetPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardStatisticsComponenetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            #region ProductCount
            var responsemessage15 = await client.GetAsync("https://localhost:44350/api/Statistics/ProductCount");
            if (responsemessage15.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata15 = await responsemessage15.Content.ReadAsStringAsync();
                ViewBag.ProductCount = jsondata15.ToString();
            }
            #endregion

            #region EmployeeNameByMaxProductCount
            var responsemessage10 = await client.GetAsync("https://localhost:44350/api/Statistics/EmployeeNameByMaxProductCount");
            if (responsemessage10.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata10 = await responsemessage10.Content.ReadAsStringAsync();
                ViewBag.EmployeeNameByMaxProductCount = jsondata10.ToString();
            }
            #endregion

            #region CityNameByMaxProductCount
            var responsemessage8 = await client.GetAsync("https://localhost:44350/api/Statistics/CityNameByMaxProductCount");
            if (responsemessage8.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata8 = await responsemessage8.Content.ReadAsStringAsync();
                ViewBag.CityNameByMaxProductCount = jsondata8.ToString();
            }
            #endregion

            #region AverageProductByRent
            var responsemessage3 = await client.GetAsync("https://localhost:44350/api/Statistics/AverageProductByRent");
            if (responsemessage3.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata3 = await responsemessage3.Content.ReadAsStringAsync();
                double FiyatBilgisi = double.Parse(jsondata3);
                ViewBag.AverageProductByRent = FiyatBilgisi.ToString("C");
            }
            #endregion

            return View();
        }
    }
}
