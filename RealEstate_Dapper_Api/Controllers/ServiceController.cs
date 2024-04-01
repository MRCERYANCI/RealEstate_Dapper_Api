
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Repositories.ServiceRepository;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ServiceController : ControllerBase
	{
		private readonly IServiceRepository _serviceRepository;

		public ServiceController(IServiceRepository serviceRepository)
		{
			_serviceRepository = serviceRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllService()
		{
			var values = await _serviceRepository.GetAllServiceAsync();
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> NewAddService(CreateServiceDto createServiceDto)
		{
			_serviceRepository.CreateService(createServiceDto);
			return Ok();
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteService(int ServiceId)
		{
			_serviceRepository.DeleteService(ServiceId);
			return Ok();
		}
		[HttpPut]
		public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
		{
			_serviceRepository.UpdateService(updateServiceDto);
			return Ok();
		}
		[HttpGet("{ServiceId}")]
		public async Task<IActionResult> GetByIdService(int ServiceId)
		{
			var value = await _serviceRepository.GetByIdService(ServiceId);
			return Ok(value);
		}
	}
}
