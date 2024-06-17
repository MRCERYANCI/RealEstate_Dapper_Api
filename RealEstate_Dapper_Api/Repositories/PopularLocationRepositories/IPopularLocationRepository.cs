using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
	public interface IPopularLocationRepository
	{
		Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync();
        Task CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto);
        Task DeletePopularLocation(int PopularLocationId);
        Task<GetByIdPopularLocationDto> GetByIdPopularLocation(int PopularLocationId);
        Task UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto);
    }
}
