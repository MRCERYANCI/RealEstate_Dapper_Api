using Microsoft.Data.SqlClient;
using System.Data;

namespace RealEstate_Dapper_Api.Models.DapperContext
{
    public class Context
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectingString;

        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectingString = _configuration.GetConnectionString("connection");  //appsettingsjson da oluşturduğumuz configuration dosyasındaki bağlantıyı alıyoruz
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectingString);

    }
}
