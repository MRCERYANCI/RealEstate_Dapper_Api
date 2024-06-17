using Dapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateCategory(CreateCategoryDto createCategoryDto)
        {
            string query = "insert into Category(CategoryName,CategoryStatus) values(@categoryname,@categorystatus)";
            var paremeters = new DynamicParameters();
            paremeters.Add("@categoryname", createCategoryDto.CategoryName);
            paremeters.Add("@categorystatus", true);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,paremeters);
            }
        }

        public async Task DeleteCategory(int CategoryId)
        {
            string query = "Delete From Category Where CategoryId=@categoryId";
            var paremeters = new DynamicParameters();
            paremeters.Add("@categoryId", CategoryId);
            using( var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paremeters);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * From Category Where CategoryStatus=1";
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCategoryDto> GetByIdCategory(int CategoryId)
        {
            string query = "Select * From Category Where CategoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", CategoryId);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query, parameters);
                return values;
            }
        }

        public async Task UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            string query = "Update Category Set CategoryName=@categoryname,CategoryStatus=@categorystatus Where CategoryId=@categoryId";
            var paremeters = new DynamicParameters();
            paremeters.Add("@categoryname", updateCategoryDto.CategoryName);
            paremeters.Add("@categorystatus", true);
            paremeters.Add("@categoryId", updateCategoryDto.CategoryId);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paremeters);
            }
        }
    }
}
