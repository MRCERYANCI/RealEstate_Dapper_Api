using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public class PopularLoationRepository : IPopularLocationRepository
	{
		private readonly Context _context;

		public PopularLoationRepository(Context context)
		{
			_context = context;
		}

        public async void CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            string query = "insert into PopularLocation(CityName,ImageUrl) values(@cityname,@imageurl)";
            var paremeters = new DynamicParameters();
            paremeters.Add("@cityname", createPopularLocationDto.CityName);
            paremeters.Add("@imageurl", createPopularLocationDto.ImageUrl);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paremeters);
            }
        }

        public async void DeletePopularLocation(int PopularLocationId)
        {
            string query = "Delete From PopularLocation Where LocationId=@locationId";
            var paremeters = new DynamicParameters();
            paremeters.Add("@locationId", PopularLocationId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paremeters);
            }
        }

        public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync()
		{
			string query = "Select * From PopularLocation";
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultPopularLocationDto>(query);
				return values.ToList();
			}
		}

        public async Task<GetByIdPopularLocationDto> GetByIdPopularLocation(int PopularLocationId)
        {
            string query = "Select * From PopularLocation Where LocationId=@locationId";
            var parameters = new DynamicParameters();
            parameters.Add("@locationId", PopularLocationId);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdPopularLocationDto>(query, parameters);
                return values;
            }
        }

        public async void UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            string query = "Update PopularLocation Set CityName=@cityname,ImageUrl=@imageurl Where LocationId=@locationId";
            var paremeters = new DynamicParameters();
            paremeters.Add("@cityname", updatePopularLocationDto.CityName);
            paremeters.Add("@imageurl", updatePopularLocationDto.ImageUrl);
            paremeters.Add("@locationId", updatePopularLocationDto.LocationId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paremeters);
            }
        }
    }
}
