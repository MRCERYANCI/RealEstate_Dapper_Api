using Dapper;
using RealEstate_Dapper_Api.Dtos.ChartDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories
{
    public class ChartRepository : IChartRepository
    {
        private readonly Context _context;

        public ChartRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultChartDto>> Get5CityForChart(int id)
        {
            string query = "Select Top(5) ProductCity,Count(*) As 'CityCount' From Product Where EmployeeID = @employeeID group by ProductCity Order By CityCount Desc";
            var paremeters = new DynamicParameters();
            paremeters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultChartDto>(query, paremeters);
                return values.ToList();
            }
        }
    }
}
