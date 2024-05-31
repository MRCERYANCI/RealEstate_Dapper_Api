using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ToDoListDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepositories
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly Context _context;

        public ToDoListRepository(Context context)
        {
            _context = context;
        }

        public void CreateToDoList(CreateToDoListDto createToDoListDto)
        {
            throw new NotImplementedException();
        }

        public async void DeleteToDoList(int ToDoListId)
        {
            string query = "Delete From ToDoList Where ToDoListID=@todolistId";
            var paremeters = new DynamicParameters();
            paremeters.Add("@todolistId", ToDoListId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paremeters);
            }
        }

        public async Task<List<Result5ToDoListDto>> Get5ToDoListAsync()
        {
            string query = "Select Top(5) * From ToDoList Order By ToDoListID desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<Result5ToDoListDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultToDoListDto>> GetAllToDoListAsync()
        {
            string query = "Select * From ToDoList";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultToDoListDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdToDoListDto> GetByIdToDoList(int ToDoListId)
        {
            string query = "Select * From ToDoList Where ToDoListID=@todolistId";
            var parameters = new DynamicParameters();
            parameters.Add("@todolistId", ToDoListId);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdToDoListDto>(query, parameters);
                return values;
            }
        }

        public void UpdateToDoList(UpdateToDoListDto updateToDoListDto)
        {
            throw new NotImplementedException();
        }
    }
}
