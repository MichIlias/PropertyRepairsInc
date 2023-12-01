using Microsoft.AspNetCore.Mvc;
using PropertyRepairsIncCommon.DTOs;
using PropertyRepairsIncConsumerAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PropertyRepairsIncConsumerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly IHouseService _houseService;
        private readonly IRepairService _repairService;

        public HouseController(IHouseService houseService, IRepairService repairService)
        {
            _houseService = houseService;
            _repairService = repairService;
        }


        // GET: api/<HouseController>
        [HttpGet]
        public async Task<IEnumerable<HouseDto>> Get()
        {
            await _repairService.ReadAndStoreRepairMessages();

            return await _houseService.GetAllHouses();
        }

        [HttpPost]
        [Route("/GetFiltered")]
        public async Task<IEnumerable<HouseDto>> GetFiltered([FromBody] HouseSearch houseSearch)
        {
            return await _houseService.GetHousesBy(houseSearch);
        }
    }
}
