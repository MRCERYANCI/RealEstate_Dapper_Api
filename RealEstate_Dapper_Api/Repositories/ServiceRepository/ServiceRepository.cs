using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
	public class ServiceRepository : IServiceRepository
	{

		private readonly Context _context;

		public ServiceRepository(Context context)
		{
			_context = context;
		}

		public async void CreateService(CreateServiceDto createServiceDto)
		{
			string query = "insert into Service(ServiceName,ServiceStatus) values(@servicename,@servicestatus)";
			var paremeters = new DynamicParameters();
			paremeters.Add("@servicename", createServiceDto.ServiceName);
			paremeters.Add("@servicestatus", true);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, paremeters);
			}
		}

		public async void DeleteService(int ServiceId)
		{
			string query = "Delete From Service Where ServiceId=@serviceId";
			var paremeters = new DynamicParameters();
			paremeters.Add("@serviceId", ServiceId);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, paremeters);
			}
		}

		public async Task<List<ResultServiceDto>> GetAllServiceAsync()
		{
			string query = "Select * From Service Where ServiceStatus=1";
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultServiceDto>(query);
				return values.ToList();
			}
		}

		public async Task<GetByIdServiceDto> GetByIdService(int ServiceId)
		{
			string query = "Select * From Service Where ServiceId=@serviceId";
			var parameters = new DynamicParameters();
			parameters.Add("@serviceId", ServiceId);
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<GetByIdServiceDto>(query, parameters);
				return values;
			}
		}

		public async void UpdateService(UpdateServiceDto updateServiceDto)
		{
			string query = "Update Service Set ServiceName=@servicename,ServiceStatus=@servicestatus Where ServiceId=@serviceId";
			var paremeters = new DynamicParameters();
			paremeters.Add("@servicename", updateServiceDto.ServiceName);
			paremeters.Add("@servicestatus", true);
			paremeters.Add("@serviceId", updateServiceDto.ServiceId);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, paremeters);
			}
		}
	}
}
