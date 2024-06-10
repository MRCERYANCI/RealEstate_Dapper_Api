using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class LayoutEstateAgentController : Controller
    {
        public IActionResult Index()
        {
            TempData["Home"] = "Ana Sayfa";
            TempData["Pages"] = "İlanlar";
            TempData["Starter"] = "Tüm İlanlarım";

            return View();
        }
    }
}
