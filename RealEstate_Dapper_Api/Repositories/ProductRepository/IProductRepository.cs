using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> ProductAdvertsListByTrueEmployeId(int EmployeeId);
        Task<List<ResultProductWithCategoryDto>> ProductAdvertsListByFalseEmployeId(int EmployeeId);
        void ProductDealOfTheDayStatusChangeTo(int ProductId, bool ProductStatus);
        Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync();
        Task<List<ResultProductAndProductDetailDto>> GetAllProductAndProductDetailsAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task<GetProductByProductIdDto> GetProductByProductIdAsync(int id);
        Task<List<ResultProductWithSearchListDto>> ResultProductWithSearchListAsync(string searchKeyValue, int propertyCategoryId, string city);
        Task<List<ResultLast3ProductDto>> ResultLast3ProductAsync(int id);
    }
}
