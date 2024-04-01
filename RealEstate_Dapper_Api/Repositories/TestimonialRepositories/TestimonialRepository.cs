using Dapper;
using RealEstate_Dapper_Api.Dtos.TestimonialDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepositories
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly Context _context;

        public TestimonialRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultTetimonialDto>> GetAllTestimonialAsync()
        {
            string query = "Select * From Testimonial Where Status=1";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultTetimonialDto>(query);
                return values.ToList();
            }
        }
    }
}
