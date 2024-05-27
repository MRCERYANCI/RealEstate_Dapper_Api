using RealEstate_Dapper_Api.Dtos.ContactDtos;

namespace RealEstate_Dapper_Api.Repositories.ContactRepositories
{
    public interface IContactRepository
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        void CreateContact(CreateContactDto createContactDto);
        void DeleteContact(int ContactId);
        Task<GetByIdContactDto> GetByIdContactAsync(int ContactId);
        Task<List<ResultLast4ContactDto>> GetLast4ContactAsync();
    }
}
