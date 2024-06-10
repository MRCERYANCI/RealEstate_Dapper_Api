using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.LoginDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Tools;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(CreateLoginDto createLoginDto)
        {
            string query = "Select * From Users Where UserName = @userName AND Password = @password";
            var parematers = new DynamicParameters();
            parematers.Add("@userName", createLoginDto.UserName);
            parematers.Add("@password", createLoginDto.Password);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetCheckAppUserViewModel>(query, parematers);

                if (values != null)
                {
                    GetCheckAppUserViewModel getCheckAppUserViewModel = new GetCheckAppUserViewModel()
                    {
                        Email = values.Email,
                        UserName = values.UserName,
                        Id = values.Id,
                        IsExist = values.IsExist,
                        PhoneNumber = values.PhoneNumber,
                        Role = values.Role,
                        TC = values.TC,
                        Surname = values.Surname,
                        Name=values.Name,
                        Image=values.Image
                    };

                    var token = JwtTokenGenerator.GenerateToken(getCheckAppUserViewModel);
                    return Ok(token);
                }
                else
                    return NotFound();

            }

        }
    }
}
