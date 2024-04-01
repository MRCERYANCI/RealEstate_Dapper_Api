using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
	public interface IServiceRepository
	{
		Task<List<ResultServiceDto>> GetAllServiceAsync();
		void CreateService(CreateServiceDto createServiceDto);
		void DeleteService(int ServiceId);
		void UpdateService(UpdateServiceDto updateServiceDto);
		Task<GetByIdServiceDto> GetByIdService(int ServiceId);
	}
}
