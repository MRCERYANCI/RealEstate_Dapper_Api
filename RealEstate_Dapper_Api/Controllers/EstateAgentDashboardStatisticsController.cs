using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticsRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentDashboardStatisticsController : ControllerBase
    {
        private readonly IDashboardStatisticsRepository _statisticsRepository;

        public EstateAgentDashboardStatisticsController(IDashboardStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        [HttpGet("AllProductCount")]
        public IActionResult AllProductCount()
        {
            return Ok(_statisticsRepository.AllProductCount());
        }

        [HttpGet("ProductCountByEmployeeId/{id}")]
        public IActionResult ProductCountByEmployeeId(int id)
        {
            return Ok(_statisticsRepository.ProductCountByEmployeeId(id));
        }

        [HttpGet("ProductCountByStatusFalse/{id}")]
        public IActionResult ProductCountByStatusFalse(int id)
        {
            return Ok(_statisticsRepository.ProductCountByStatusFalse(id));
        }

        [HttpGet("ProductCountByStatusTrue/{id}")]
        public IActionResult ProductCountByStatusTrue(int id)
        {
            return Ok(_statisticsRepository.ProductCountByStatusTrue(id));
        }
    }
}
