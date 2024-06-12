namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticsRepositories
{
    public interface IDashboardStatisticsRepository
    {
        int ProductCountByEmployeeId(int id);
        int ProductCountByStatusTrue(int id);
        int ProductCountByStatusFalse(int id);
        int AllProductCount();

    }
}
