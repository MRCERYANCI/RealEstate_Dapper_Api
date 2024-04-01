using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDtos;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public interface IWhoWeAreRepository
    {
        Task<List<ResultWhoWeAreDto>> GetAllWhoWeAreAsync();
        void CreateWhoWeAre(CreateWhoWeAreDto createWhoWeAreDto);
        void DeleteWhoWeAre(int WhoWeAreId);
        void UpdateWhoWeAre(UpdateWhoWeAreDto updateWhoWeAre);
        Task<GetByIdWhoWeAreDto> GetByIdWhoWeAre(int WhoWeAreId);
    }
}
