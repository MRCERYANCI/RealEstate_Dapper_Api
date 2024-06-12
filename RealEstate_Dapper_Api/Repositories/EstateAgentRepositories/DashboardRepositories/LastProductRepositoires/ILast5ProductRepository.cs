using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductRepositoires
{
    public interface ILast5ProductRepository
    {
        Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync(int id);
    }
}
