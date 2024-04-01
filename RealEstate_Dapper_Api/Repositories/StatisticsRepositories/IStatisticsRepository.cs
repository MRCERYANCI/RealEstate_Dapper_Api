namespace RealEstate_Dapper_Api.Repositories.StatisticsRepositories
{
    public interface IStatisticsRepository
    {
        int CategoryCount();
        int ActiveCategoryCount();
        int PasiveCategoryCount();
        int ProductCount();
        int ApartmentCount();
        string CategoryNameByMaxProductCount();
        decimal AverageProductByRent();
        decimal AverageProductBySale();
        string CityNameByMaxProductCount();
        int DifferentCityCount();
        decimal LastProductPrice();
        string NewestBuildingYear();
        string OldestBuildingYear();
        int AvgRoomCount();
        int ActiveEmployeeCount();
        string EmployeeNameByMaxProductCount();

    }
}
