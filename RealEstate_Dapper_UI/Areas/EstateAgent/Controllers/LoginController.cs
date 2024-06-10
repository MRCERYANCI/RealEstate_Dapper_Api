using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.LoginDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
        {
            var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk
            var jsonData = JsonConvert.SerializeObject(createLoginDto);//Modelden gelen veriyi Json Türüne Çevirdik, Normal Veriyi Json Türüne Çevirmek için SerializeObject Kullanılır
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//İçeriğin dönüşümü için kullancaz(content,encoding,mediaType)
            var responseMessage = await client.PostAsync("https://localhost:44350/api/Login", stringContent);
            if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
            {
                var tokenData = await responseMessage.Content.ReadAsStringAsync();
                var tokenModel = System.Text.Json.JsonSerializer.Deserialize<JwtResponseModel>(tokenData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if(tokenModel != null)
                {
                    JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                    var token = jwtSecurityTokenHandler.ReadJwtToken(tokenModel.Token);
                    var claims = token.Claims.ToList();

                    if(tokenModel.Token != null)
                    {
                        claims.Add(new Claim("realestatetoken",tokenModel.Token.ToString()));
                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true  //token hatırlansın mı
                        };

                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);

                        return RedirectToAction("Index", "MyAdverts");
                    }
                }
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            // Kullanıcı oturumunu sonlandır
            await HttpContext.SignOutAsync();

            // Cookie'yi sil
            if (Request.Cookies["CokkececiEmlakJwt"] != null)
            {
                Response.Cookies.Delete("CokkececiEmlakJwt");
            }

            // giriş sayfasına yönlendir
            return RedirectToAction("Index", "Login");
        }
    }
}
