using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductImagesDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductImagesRepositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly Context _context;

        public ProductImageRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<GetProductImageByProductDto>> GetProductImageByProductIdAsync(int id)
        {
            string query = "Select * From ProductImage Where ProductId = @productId";
            var paremeters = new DynamicParameters();
            paremeters.Add("@productId", id);
            using(var connectiom = _context.CreateConnection())
            {
                var values = await connectiom.QueryAsync<GetProductImageByProductDto>(query, paremeters);
                return values.ToList();
            }
        }
    }
}
