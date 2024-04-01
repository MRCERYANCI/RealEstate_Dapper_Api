using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Repositories.EmployeRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeRepository _employeeRepository;

		public EmployeeController(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}

		[HttpGet]
		public async Task<IActionResult> EmployeeList()
		{
			var Values = await _employeeRepository.GetAllEmployeeAsync();
			return Ok(Values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
		{
			_employeeRepository.CreateEmployee(createEmployeeDto);
			return Ok();
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteEmployee(int EmployeeId)
		{
			_employeeRepository.DeleteEmployee(EmployeeId);
			return Ok();
		}
		[HttpPut]
		public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
		{
			_employeeRepository.UpdateEmployee(updateEmployeeDto);
			return Ok();
		}
		[HttpGet("{EmployeeId}")]
		public async Task<IActionResult> GetByIdEmployee(int EmployeeId)
		{
			var value = await _employeeRepository.GetByIdEmployee(EmployeeId);
			return Ok(value);
		}
	}
}
