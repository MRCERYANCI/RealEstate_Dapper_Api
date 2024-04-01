using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Repositories.BottomGridRepository;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BottomGridController : ControllerBase
	{
		private readonly IBottomGridRepository _bottomGridRepository;

		public BottomGridController(IBottomGridRepository bottomGridRepository)
		{
			_bottomGridRepository = bottomGridRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllBottomGrid()
		{
			var Values = await _bottomGridRepository.GetAllBottomGridAsync();
			return Ok(Values);
		}

        [HttpPost]
        public async Task<IActionResult> CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
        {
            _bottomGridRepository.CreateBottomGrid(createBottomGridDto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBottomGrid(int BottomGridId)
        {
            _bottomGridRepository.DeleteBottomGrid(BottomGridId);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBottomGrid(UpdateBttomGridDto updateBottomGridDto)
        {
            _bottomGridRepository.UpdateBottomGrid(updateBottomGridDto);
            return Ok();
        }
        [HttpGet("{BottomGridId}")]
        public async Task<IActionResult> GetByIdBottomGrid(int BottomGridId)
        {
            var value = await _bottomGridRepository.GetByIdBottomGrid(BottomGridId);
            return Ok(value);
        }
    }
}
