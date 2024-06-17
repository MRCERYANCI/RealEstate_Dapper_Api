using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDtos;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public interface IWhoWeAreRepository
    {
        Task<List<ResultWhoWeAreDto>> GetAllWhoWeAreAsync();
        Task CreateWhoWeAre(CreateWhoWeAreDto createWhoWeAreDto);
        Task DeleteWhoWeAre(int WhoWeAreId);
        Task UpdateWhoWeAre(UpdateWhoWeAreDto updateWhoWeAre);
        Task<GetByIdWhoWeAreDto> GetByIdWhoWeAre(int WhoWeAreId);
    }
}
