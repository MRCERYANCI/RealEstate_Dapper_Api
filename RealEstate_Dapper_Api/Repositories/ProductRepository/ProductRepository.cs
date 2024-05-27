using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * From Product";
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "Select product.ProductID,product.ProductTitle,product.ProductPrice,product.ProductCity,product.ProductDistrict,product.ProductAdress,product.ProductDescription,product.ProductCoverImage,product.ProductType,category.CategoryName,Product.DealOfTheDay " +
                "From Product product inner join Category category on product.ProductCategory=category.CategoryId";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

		public async void ProductDealOfTheDayStatusChangeTo(int ProductId, bool ProductStatus)
		{
            string Query = "Update Product Set DealOfTheDay=@status Where ProductId=@productıd";
            var parameters = new DynamicParameters();
            parameters.Add("@status", ProductStatus);
            parameters.Add("@productıd", ProductId);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(Query, parameters);
            }
		}
	}
}
