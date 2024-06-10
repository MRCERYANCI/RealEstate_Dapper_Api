using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.Controllers
{
    [Authorize]
    [Area("EstateAgent")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            TempData["Home"] = "Ana Sayfa";
            TempData["Pages"] = "Dashboard";
            TempData["Starter"] = "Tablolar & İstatistikler";

            return View();
        }
    }
}
