using Microsoft.AspNetCore.Mvc;
using PropertyRepairsIncCommon.DTOs;
using PropertyRepairsIncConsumerAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PropertyRepairsIncConsumerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairController : ControllerBase
    {
        private readonly IRepairService _repairService;

        public RepairController(IRepairService repairService)
        {
            _repairService = repairService;
        }



        // GET: api/<RepairController>
        [HttpGet]
        public async Task<IEnumerable<RepairDto>> Get()
        {
            return await _repairService.GetAll();
        }

        [HttpGet("{houseId}")]
        public async Task<IEnumerable<RepairDto>> GetByHouse(int houseId)
        {
            return await _repairService.GetRepairForSpecificHouse(houseId);
        }

    }
}
