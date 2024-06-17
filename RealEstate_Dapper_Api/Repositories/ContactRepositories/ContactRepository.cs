using Dapper;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ContactRepositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _context;

        public ContactRepository(Context context)
        {
            _context = context;
        }

        public Task CreateContact(CreateContactDto createContactDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteContact(int ContactId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<GetByIdContactDto> GetByIdContactAsync(int ContactId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultLast4ContactDto>> GetLast4ContactAsync()
        {
            string query = "Select Top(4) * From Contact Order By SendDate Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast4ContactDto>(query);
                return values.ToList();
            }
        }
    }
}
