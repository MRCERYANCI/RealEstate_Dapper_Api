using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
	public interface IServiceRepository
	{
		Task<List<ResultServiceDto>> GetAllServiceAsync();
        Task CreateService(CreateServiceDto createServiceDto);
        Task DeleteService(int ServiceId);
        Task UpdateService(UpdateServiceDto updateServiceDto);
		Task<GetByIdServiceDto> GetByIdService(int ServiceId);
	}
}
