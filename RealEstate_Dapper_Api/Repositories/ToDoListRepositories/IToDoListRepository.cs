using RealEstate_Dapper_Api.Dtos.ToDoListDtos;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepositories
{
    public interface IToDoListRepository
    {
        Task<List<ResultToDoListDto>> GetAllToDoListAsync();
        Task<List<Result5ToDoListDto>> Get5ToDoListAsync();
        void CreateToDoList(CreateToDoListDto createToDoListDto);
        void DeleteToDoList(int ToDoListId);
        void UpdateToDoList(UpdateToDoListDto updateToDoListDto);
        Task<GetByIdToDoListDto> GetByIdToDoList(int ToDoListId);
    }
}
