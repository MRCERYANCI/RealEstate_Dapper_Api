using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticsRepositories
{
    public class DashboardStatisticsRepository : IDashboardStatisticsRepository
    {
        private readonly Context _context;

        public DashboardStatisticsRepository(Context context)
        {
            _context = context;
        }

        public int AllProductCount()
        {
            string query = "Select Count(*) From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ProductCountByEmployeeId(int id)
        {
            string query = "Select Count(*) From Product Where EmployeeID = @employeeID";
            var paremeters = new DynamicParameters();
            paremeters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query,paremeters);
                return values;
            }
        }

        public int ProductCountByStatusFalse(int id)
        {
            string query = "Select Count(*) From Product Where EmployeeID = @employeeID AND Status = @status";
            var paremeters = new DynamicParameters();
            paremeters.Add("@employeeID", id);
            paremeters.Add("@status", false);
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query, paremeters);
                return values;
            }
        }

        public int ProductCountByStatusTrue(int id)
        {
            string query = "Select Count(*) From Product Where EmployeeID = @employeeID AND Status = @status";
            var paremeters = new DynamicParameters();
            paremeters.Add("@employeeID", id);
            paremeters.Add("@status", true);
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query, paremeters);
                return values;
            }
        }
    }
}
