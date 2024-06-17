using RealEstate_Dapper_Api.Dtos.BottomGridDtos; 

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepository
{
	public interface IBottomGridRepository
	{
		Task<List<ResultBottomGridDto>> GetAllBottomGridAsync();
		Task CreateBottomGrid(CreateBottomGridDto createBottomGridDto);
        Task DeleteBottomGrid(int BottomGridId);
        Task UpdateBottomGrid(UpdateBttomGridDto updateBttomGridDto);
		Task<GetBottomGridDto> GetByIdBottomGrid(int BottomGridId);
	}
}
