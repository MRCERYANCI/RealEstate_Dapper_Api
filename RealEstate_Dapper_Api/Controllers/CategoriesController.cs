using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var Values = await _categoryRepository.GetAllCategoryAsync();
            return Ok(Values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            _categoryRepository.CreateCategory(createCategoryDto);
            return Ok("Kategori Başarılı Bir Şekilde Sisteme Kayıt Edilmiştir");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int CategoryId)
        {
            _categoryRepository.DeleteCategory(CategoryId);
            return Ok("Kategori Başarılı Bir Şekilde Silinmiştir");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            _categoryRepository.UpdateCategory(updateCategoryDto);
            return Ok("Kategori Başarıyla Güncellenmiştir");
        }
        [HttpGet("{CategoryId}")]
        public async Task<IActionResult> GetByIdCategory(int CategoryId)
        {
            var value = await _categoryRepository.GetByIdCategory(CategoryId);
            return Ok(value);
        }
    }
}
