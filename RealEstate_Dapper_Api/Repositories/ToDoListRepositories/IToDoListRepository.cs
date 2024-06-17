using RealEstate_Dapper_Api.Dtos.ToDoListDtos;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepositories
{
    public interface IToDoListRepository
    {
        Task<List<ResultToDoListDto>> GetAllToDoListAsync();
        Task<List<Result5ToDoListDto>> Get5ToDoListAsync();
        Task CreateToDoList(CreateToDoListDto createToDoListDto);
        Task DeleteToDoList(int ToDoListId);
        Task UpdateToDoList(UpdateToDoListDto updateToDoListDto);
        Task<GetByIdToDoListDto> GetByIdToDoList(int ToDoListId);
    }
}
