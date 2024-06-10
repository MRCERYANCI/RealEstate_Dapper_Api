using Microsoft.AspNetCore.Mvc;
namespace RealEstate_Dapper_UI.Areas.EstateAgent.ViewComponents.AdminLayout
{
    public class _EstateAgentLayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
