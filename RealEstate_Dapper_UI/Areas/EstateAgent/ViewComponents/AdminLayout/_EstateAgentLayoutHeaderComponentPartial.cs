using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.ViewComponents.AdminLayout
{
    public class _EstateAgentLayoutHeaderComponentPartial : ViewComponent
    {
        private readonly ILoginService _loginService;

        public _EstateAgentLayoutHeaderComponentPartial(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public IViewComponentResult Invoke()
        {
            var nameSurname = _loginService.Name + " " + _loginService.Surname;
            var image = _loginService.Image;
            ViewBag.Image = image;
            ViewBag.Name = nameSurname;
            return View();
        }
    }
}
