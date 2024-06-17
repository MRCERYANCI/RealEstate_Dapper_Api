using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EmployeRepositories
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly Context _context;

		public EmployeeRepository(Context context)
		{
			_context = context;
		}

		public async Task CreateEmployee(CreateEmployeeDto createEmployeeDto)
		{
			string query = "insert into Employee(EmployeeName,EmployeeTitle,EmployeeMail,EmployeePhoneNumber,EmployeeImageUrl,EmployeeStatus) values(@name,@title,@mail,@phonenumber,@imageUrl,@status)";
			var paremeters = new DynamicParameters();
			paremeters.Add("@name", createEmployeeDto.EmployeeName);
			paremeters.Add("@title", createEmployeeDto.EmployeeTitle);
			paremeters.Add("@mail", createEmployeeDto.EmployeeMail);
			paremeters.Add("@phonenumber", createEmployeeDto.EmployeePhoneNumber);
			paremeters.Add("@imageUrl", createEmployeeDto.EmployeeImageUrl);
			paremeters.Add("@status", true);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, paremeters);
			}
		}

		public async Task DeleteEmployee(int EmployeeId)
		{
			string query = "Delete From Employee Where EmployeeID=@employeeID";
			var paremeters = new DynamicParameters();
			paremeters.Add("@employeeID", EmployeeId);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, paremeters);
			}
		}

		public async Task<List<ResultEmployeeDto>> GetAllEmployeeAsync()
		{
			string query = "Select * From Employee Where EmployeeStatus = 1";
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultEmployeeDto>(query);
				return values.ToList();
			}
		}

		public async Task<GetByIdEmployeeDto> GetByIdEmployee(int EmployeeId)
		{
			string query = "Select * From Employee Where EmployeeID=@employeeID";
			var parameters = new DynamicParameters();
			parameters.Add("@employeeID", EmployeeId);
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<GetByIdEmployeeDto>(query, parameters);
				return values;
			}
		}

		public async Task UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
		{
			string query = "Update Employee Set EmployeeName=@name,EmployeeTitle=@title,EmployeeMail=@mail,EmployeePhoneNumber=@phonenumber,EmployeeImageUrl=@imageUrl,EmployeeStatus=@status Where @EmployeeID=@employeeID";
			var paremeters = new DynamicParameters();
			paremeters.Add("@name", updateEmployeeDto.EmployeeName);
			paremeters.Add("@title", updateEmployeeDto.EmployeeTitle);
			paremeters.Add("@mail", updateEmployeeDto.EmployeeMail);
			paremeters.Add("@phonenumber", updateEmployeeDto.EmployeePhoneNumber);
			paremeters.Add("@imageUrl", updateEmployeeDto.EmployeeImageUrl);
			paremeters.Add("@status", true);
			paremeters.Add("@employeeID", updateEmployeeDto.EmployeeID);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, paremeters);
			}
		}
	}
}
