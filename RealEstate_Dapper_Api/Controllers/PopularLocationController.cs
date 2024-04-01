
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PopularLocationController : ControllerBase
	{
		private readonly IPopularLocationRepository _popularLocationRepository;

		public PopularLocationController(IPopularLocationRepository popularLocationRepository)
		{
			_popularLocationRepository = popularLocationRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllPopularLocation()
		{
			var values = await _popularLocationRepository.GetAllPopularLocationAsync();
			return Ok(values);
		}

        [HttpPost]
        public async Task<IActionResult> NewAddPopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            _popularLocationRepository.CreatePopularLocation(createPopularLocationDto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePopularLocation(int PopularLocationId)
        {
            _popularLocationRepository.DeletePopularLocation(PopularLocationId);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            _popularLocationRepository.UpdatePopularLocation(updatePopularLocationDto);
            return Ok();
        }
        [HttpGet("{PopularLocationId}")]
        public async Task<IActionResult> GetByIdPopularLocation(int PopularLocationId)
        {
            var value = await _popularLocationRepository.GetByIdPopularLocation(PopularLocationId);
            return Ok(value);
        }
    }
}
