using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RealEstate_Dapper_UI.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<ActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            #region ActiveCategoryCount
            var responsemessage = await client.GetAsync("https://localhost:44350/api/Statistics/ActiveCategoryCount");
            if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                ViewBag.ActiveCategoryCount = jsondata;
            }
            #endregion

            #region ActiveEmployeeCount
            var responsemessage1 = await client.GetAsync("https://localhost:44350/api/Statistics/ActiveEmployeeCount");
            if (responsemessage1.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata1 = await responsemessage1.Content.ReadAsStringAsync();
                ViewBag.ActiveEmployeeCount = jsondata1;
            }
            #endregion

            #region ApartmentCount
            var responsemessage2 = await client.GetAsync("https://localhost:44350/api/Statistics/ApartmentCount");
            if (responsemessage2.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata2 = await responsemessage2.Content.ReadAsStringAsync();
                ViewBag.ApartmentCount = jsondata2;
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

            #region AverageProductBySale
            var responsemessage4 = await client.GetAsync("https://localhost:44350/api/Statistics/AverageProductBySale");
            if (responsemessage4.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata4 = await responsemessage4.Content.ReadAsStringAsync();
                double FiyatBilgisi = double.Parse(jsondata4);
                ViewBag.AverageProductBySale = FiyatBilgisi.ToString("C");
            }
            #endregion

            #region CategoryCount
            var responsemessage5 = await client.GetAsync("https://localhost:44350/api/Statistics/CategoryCount");
            if (responsemessage5.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata5 = await responsemessage5.Content.ReadAsStringAsync();
                ViewBag.CategoryCount = jsondata5.ToString();
            }
            #endregion

            #region AvgRoomCount
            var responsemessage6 = await client.GetAsync("https://localhost:44350/api/Statistics/AvgRoomCount");
            if (responsemessage6.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata6 = await responsemessage6.Content.ReadAsStringAsync();
                ViewBag.AvgRoomCount = jsondata6.ToString();
            }
            #endregion

            #region CategoryNameByMaxProductCount
            var responsemessage7 = await client.GetAsync("https://localhost:44350/api/Statistics/CategoryNameByMaxProductCount");
            if (responsemessage7.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata7 = await responsemessage7.Content.ReadAsStringAsync();
                ViewBag.CategoryNameByMaxProductCount = jsondata7.ToString();
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

            #region DifferentCityCount
            var responsemessage9 = await client.GetAsync("https://localhost:44350/api/Statistics/DifferentCityCount");
            if (responsemessage9.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata9 = await responsemessage9.Content.ReadAsStringAsync();
                ViewBag.DifferentCityCount = jsondata9.ToString();
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

            #region LastProductPrice
            var responsemessage11 = await client.GetAsync("https://localhost:44350/api/Statistics/LastProductPrice");
            if (responsemessage11.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata11 = await responsemessage11.Content.ReadAsStringAsync();
                double FiyatBilgisi = double.Parse(jsondata11);
                ViewBag.LastProductPrice = FiyatBilgisi.ToString("C");
            }
            #endregion

            #region NewestBuildingYear
            var responsemessage12 = await client.GetAsync("https://localhost:44350/api/Statistics/NewestBuildingYear");
            if (responsemessage12.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata12 = await responsemessage12.Content.ReadAsStringAsync();
                var BinaYasFarkı = DateTime.Now.Year - int.Parse(jsondata12);
                ViewBag.NewestBuildingYear = BinaYasFarkı;
            }
            #endregion

            #region OldestBuildingYear
            var responsemessage13 = await client.GetAsync("https://localhost:44350/api/Statistics/OldestBuildingYear");
            if (responsemessage13.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata13 = await responsemessage13.Content.ReadAsStringAsync();
                var BinaYasFarkı = DateTime.Now.Year - int.Parse(jsondata13);
                ViewBag.OldestBuildingYear = BinaYasFarkı;
            }
            #endregion

            #region PasiveCategoryCount
            var responsemessage14 = await client.GetAsync("https://localhost:44350/api/Statistics/PasiveCategoryCount");
            if (responsemessage14.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata14 = await responsemessage14.Content.ReadAsStringAsync();
                ViewBag.PasiveCategoryCount = jsondata14.ToString();
            }
            #endregion

            #region ProductCount
            var responsemessage15 = await client.GetAsync("https://localhost:44350/api/Statistics/ProductCount");
            if (responsemessage15.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata15 = await responsemessage15.Content.ReadAsStringAsync();
                ViewBag.ProductCount = jsondata15.ToString();
            }
            #endregion

            return View();
        }
    }
}
