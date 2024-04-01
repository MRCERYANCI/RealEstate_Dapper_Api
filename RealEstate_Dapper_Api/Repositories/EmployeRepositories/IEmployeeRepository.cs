using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;

namespace RealEstate_Dapper_Api.Repositories.EmployeRepositories
{
	public interface IEmployeeRepository
	{
		Task<List<ResultEmployeeDto>> GetAllEmployeeAsync();
		void CreateEmployee(CreateEmployeeDto createEmployeeDto);
		void DeleteEmployee(int EmployeeId);
		void UpdateEmployee(UpdateEmployeeDto updateEmployeeDto);
		Task<GetByIdEmployeeDto> GetByIdEmployee(int EmployeeId);
	}
}
