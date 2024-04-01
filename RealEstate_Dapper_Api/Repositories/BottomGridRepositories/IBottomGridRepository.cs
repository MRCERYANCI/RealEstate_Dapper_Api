using RealEstate_Dapper_Api.Dtos.BottomGridDtos; 

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepository
{
	public interface IBottomGridRepository
	{
		Task<List<ResultBottomGridDto>> GetAllBottomGridAsync();
		void CreateBottomGrid(CreateBottomGridDto createBottomGridDto);
		void DeleteBottomGrid(int BottomGridId);
		void UpdateBottomGrid(UpdateBttomGridDto updateBttomGridDto);
		Task<GetBottomGridDto> GetByIdBottomGrid(int BottomGridId);
	}
}
