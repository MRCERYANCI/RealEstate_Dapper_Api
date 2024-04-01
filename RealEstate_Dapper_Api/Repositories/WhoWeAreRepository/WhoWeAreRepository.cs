using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public class WhoWeAreRepository : IWhoWeAreRepository
    {
        private readonly Context _context;

        public WhoWeAreRepository(Context context)
        {
            _context = context;
        }

        public async void CreateWhoWeAre(CreateWhoWeAreDto createWhoWeAreDto)
        {
            string query = "insert into WhoWeAre(WhoWeAreTitle,WhoWeAreSubTitle,WhoWeAreDescription1,WhoWeAreDescription2) values(@whoweareTitle,@whoweareSubTitle,@whoweareDescription1,@whoweareDescription2)";
            var paremeters = new DynamicParameters();
            paremeters.Add("@whoweareTitle", createWhoWeAreDto.WhoWeAreTitle);
            paremeters.Add("@whoweareSubTitle", createWhoWeAreDto.WhoWeAreSubTitle);
            paremeters.Add("@whoweareDescription1", createWhoWeAreDto.WhoWeAreDescription1);
            paremeters.Add("@whoweareDescription2", createWhoWeAreDto.WhoWeAreDescription2);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paremeters);
            }
        }

        public async void DeleteWhoWeAre(int WhoWeAreId)
        {
            string query = "Delete From WhoWeAre Where WhoWeAreId=@whoweareId";
            var paremeters = new DynamicParameters();
            paremeters.Add("@whoweareId", WhoWeAreId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paremeters);
            }
        }

        public async Task<List<ResultWhoWeAreDto>> GetAllWhoWeAreAsync()
        {
            string query = "Select * From WhoWeAre";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdWhoWeAreDto> GetByIdWhoWeAre(int WhoWeAreId)
        {
            string query = "Select * From WhoWeAre Where WhoWeAreId=@whoweareId";
            var parameters = new DynamicParameters();
            parameters.Add("@whoweareId", WhoWeAreId);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdWhoWeAreDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateWhoWeAre(UpdateWhoWeAreDto updateWhoWeAre)
        {
            string query = "Update WhoWeAre Set WhoWeAreTitle=@whoweareTitle,WhoWeAreSubTitle=@whoweareSubTitle,WhoWeAreDescription1=@whoweareDescription1,WhoWeAreDescription2=@whoweareDescription2 Where WhoWeAreId=@whoweareId";
            var paremeters = new DynamicParameters();
            paremeters.Add("@whoweareId", updateWhoWeAre.WhoWeAreId);
            paremeters.Add("@whoweareTitle", updateWhoWeAre.WhoWeAreTitle);
            paremeters.Add("@whoweareSubTitle", updateWhoWeAre.WhoWeAreSubTitle);
            paremeters.Add("@whoweareDescription1", updateWhoWeAre.WhoWeAreDescription1);
            paremeters.Add("@whoweareDescription2", updateWhoWeAre.WhoWeAreDescription2);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.ExecuteAsync(query, paremeters);
            }
        }
    }
}
