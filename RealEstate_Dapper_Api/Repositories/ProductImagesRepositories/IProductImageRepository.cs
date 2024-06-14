using RealEstate_Dapper_Api.Dtos.ProductImagesDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductImagesRepositories
{
    public interface IProductImageRepository
    {
        Task<List<GetProductImageByProductDto>> GetProductImageByProductIdAsync(int id);
    }
}
