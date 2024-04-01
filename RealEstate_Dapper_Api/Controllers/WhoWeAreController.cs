using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDtos;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreController : ControllerBase
    {
        private readonly IWhoWeAreRepository _whoWeAreRepository;

        public WhoWeAreController(IWhoWeAreRepository whoWeAreRepository)
        {
            _whoWeAreRepository = whoWeAreRepository;
        }


        [HttpGet]
        public async Task<IActionResult> WhoWeAreList()
        {
            var Values = await _whoWeAreRepository.GetAllWhoWeAreAsync();
            return Ok(Values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAre(CreateWhoWeAreDto createWhoWeAreDto)
        {
            _whoWeAreRepository.CreateWhoWeAre(createWhoWeAreDto);
            return Ok("Hakkımzda Başarılı Bir Şekilde Sisteme Kayıt Edilmiştir");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWhoWeAre(int WhoWeAreId)
        {
            _whoWeAreRepository.DeleteWhoWeAre(WhoWeAreId);
            return Ok("Hakkımzda Başarılı Bir Şekilde Silinmiştir");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateWhoWeAre(UpdateWhoWeAreDto updateWhoWeAreDto)
        {
            _whoWeAreRepository.UpdateWhoWeAre(updateWhoWeAreDto);
            return Ok("Hakkımzıda Alanı Başarıyla Güncellenmiştir");
        }
        [HttpGet("{WhoWeAreId}")]
        public async Task<IActionResult> GetByIdWhoWeAre(int WhoWeAreId)
        {
            var value = await _whoWeAreRepository.GetByIdWhoWeAre(WhoWeAreId);
            return Ok(value);
        }
    }
}
