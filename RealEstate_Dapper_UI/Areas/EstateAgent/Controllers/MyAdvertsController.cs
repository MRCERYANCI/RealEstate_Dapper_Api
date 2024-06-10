using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class MyAdvertsController : Controller
    {
        public IActionResult Index()
        {
            TempData["Home"] = "Ana Sayfa";
            TempData["Pages"] = "Profil";
            TempData["Starter"] = "Profil Bilgileri";
            return View();
        }
    }
}
