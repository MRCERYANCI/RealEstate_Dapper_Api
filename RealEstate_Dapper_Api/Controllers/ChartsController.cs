using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase
    {
        private readonly IChartRepository _chartRepository;

        public ChartsController(IChartRepository chartRepository)
        {
            _chartRepository = chartRepository;
        }

        [HttpGet("Get5CityForChart/{id}")]
        public async Task<IActionResult> Get5CityForChart(int id)
        {
            return Ok(await _chartRepository.Get5CityForChart(id));
        }
    }
}
