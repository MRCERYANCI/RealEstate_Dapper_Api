using System.Security.Claims;

namespace RealEstate_Dapper_UI.Services
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetUserId => _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

        public string Name => _contextAccessor.HttpContext.User.FindFirst("Name").Value;

        public string Surname => _contextAccessor.HttpContext.User.FindFirst("Surname").Value;

        public string Image => _contextAccessor.HttpContext.User.FindFirst("Image").Value;
    }
}
