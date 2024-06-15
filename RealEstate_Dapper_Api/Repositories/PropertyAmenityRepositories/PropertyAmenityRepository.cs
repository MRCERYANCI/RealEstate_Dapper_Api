using Dapper;
using RealEstate_Dapper_Api.Dtos.PropertyAmenityDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PropertyAmenityRepositories
{
    public class PropertyAmenityRepository : IPropertyAmenityRepository
    {
        private readonly Context _context;

        public PropertyAmenityRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultPropertyAmenityByStatusTrueDto>> ResultPropertyAmenityByStatusTrueAsync(int id)
        {
            string query = "Select Amenity.Title,PropertyAmenity.Status From PropertyAmenity inner join Amenity On PropertyAmenity.AmenityId = Amenity.AmenityId Where PropertyAmenity.ProductId = @productId AND PropertyAmenity.Status = 1";
            var paremeters = new DynamicParameters();
            paremeters.Add("@productId", id);
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPropertyAmenityByStatusTrueDto>(query, paremeters);
                return values.ToList();
            }
        }
    }
}
