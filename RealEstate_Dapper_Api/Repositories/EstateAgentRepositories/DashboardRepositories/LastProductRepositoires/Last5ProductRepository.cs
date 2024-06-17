using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductRepositoires
{
    public class Last5ProductRepository : ILast5ProductRepository
    {
        private readonly Context _context;

        public Last5ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync(int id)
        {
            string query = "SELECT TOP(5) product.ProductID,product.ProductTitle,product.ProductPrice,product.ProductCity,product.ProductDistrict,category.CategoryName FROM Product inner join Category ON Product.ProductCategory = Category.CategoryId WHERE UserId = @employeeID ORDER BY ProductID DESC ";
            var paremeters = new DynamicParameters();
            paremeters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query,paremeters);
                return values.ToList();
            }
        }
    }
}
