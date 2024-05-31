using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.Controllers
{
    public class LayoutEstateAgentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
