﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productRepository.GetAllProductAsync();
            return Ok(values);
        }
        [HttpGet("ProductListWithCategory")] //Birden fazla get isteği olursa metot adı http get bölümüne yazılır
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _productRepository.GetAllProductWithCategoryAsync();
            return Ok(values);
        }

        [HttpGet("ProductDealOfTheDayStatusChangeTo")]
        public IActionResult ProductDealOfTheDayStatusChangeTo(int ProductId,bool ProductStatus)
        {
            _productRepository.ProductDealOfTheDayStatusChangeTo(ProductId, ProductStatus);
            return Ok();
        }

        [HttpGet("Last5ProductList")]
        public async Task<IActionResult> Last5ProductList()
        {
            return Ok(await _productRepository.GetLast5ProductAsync());
        }

        [HttpGet("ProductAdvertsListByTrueEmployeId/{EmployeId}")]
        public async Task<IActionResult> ProductAdvertsListByTrueEmployeId(int EmployeId)
        {
            return Ok(await _productRepository.ProductAdvertsListByTrueEmployeId(EmployeId));
        }

        [HttpGet("ProductAdvertsListByFalseEmployeId/{EmployeId}")]
        public async Task<IActionResult> ProductAdvertsListByFalseEmployeId(int EmployeId)
        {
            return Ok(await _productRepository.ProductAdvertsListByFalseEmployeId(EmployeId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productRepository.CreateProductAsync(createProductDto);
            return Ok("İlan Başarıyla Eklenmiştir");
        }

    }
}
