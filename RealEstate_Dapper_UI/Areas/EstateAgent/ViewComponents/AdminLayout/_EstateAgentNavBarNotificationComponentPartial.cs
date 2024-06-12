using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.ViewComponents.AdminLayout
{
    public class _EstateAgentNavBarNotificationComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public _EstateAgentNavBarNotificationComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
