using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepository
{
	public class BottomGridRepository : IBottomGridRepository
	{
		private readonly Context _context;

		public BottomGridRepository(Context context)
		{
			_context = context;
		}

		public async void CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
		{
            string query = "insert into BottomGrid(Icon,Title,Description) values(@icon,@title,@description)";
            var paremeters = new DynamicParameters();
            paremeters.Add("@icon", createBottomGridDto.Icon);
            paremeters.Add("@title", createBottomGridDto.Title);
            paremeters.Add("@description", createBottomGridDto.Description);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paremeters);
            }
        }

		public async void DeleteBottomGrid(int BottomGridId)
		{
            string query = "Delete From BottomGrid Where BottomGridId=@bottomgridid";
            var paremeters = new DynamicParameters();
            paremeters.Add("@bottomgridid", BottomGridId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paremeters);
            }
        }

		public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
		{
			string query = "Select * From BottomGrid";
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultBottomGridDto>(query);
				return values.ToList();
			}
		}

		public async Task<GetBottomGridDto> GetByIdBottomGrid(int BottomGridId)
		{
            string query = "Select * From BottomGrid Where BottomGridId=@bottomgridid";
            var parameters = new DynamicParameters();
            parameters.Add("@bottomgridid", BottomGridId);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetBottomGridDto>(query, parameters);
                return values;
            }
        }

		public async void UpdateBottomGrid(UpdateBttomGridDto updateBttomGridDto)
		{
            string query = "Update BottomGrid Set Icon=@icon,Title=@title,Description=@description Where BottomGridId=@bottomgridid ";
            var paremeters = new DynamicParameters();
            paremeters.Add("@icon", updateBttomGridDto.Icon);
            paremeters.Add("@title", updateBttomGridDto.Title);
            paremeters.Add("@description", updateBttomGridDto.Description);
            paremeters.Add("@bottomgridid", updateBttomGridDto.BottomGridId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paremeters);
            }
        }
	}
}
