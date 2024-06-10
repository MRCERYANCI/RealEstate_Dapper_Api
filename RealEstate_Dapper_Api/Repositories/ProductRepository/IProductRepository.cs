﻿using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> ProductAdvertsListByEmployeId(int EmployeeId);
        void ProductDealOfTheDayStatusChangeTo(int ProductId, bool ProductStatus);
        Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync();
    }
}
