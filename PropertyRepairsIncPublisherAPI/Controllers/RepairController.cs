using Microsoft.AspNetCore.Mvc;
using PropertyRepairsIncCommon.DTOs;
using PropertyRepairsIncPublisherAPI.Rabbit;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PropertyRepairsIncPublisherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairController : ControllerBase
    {
        private readonly IRabbitMqProducer _rabbitMqProducer;
        private readonly ILogger<RepairController> _logger;

        public RepairController(IRabbitMqProducer rabbitMqProducer, ILogger<RepairController> logger)
        {
            _rabbitMqProducer = rabbitMqProducer;
            _logger = logger;
        }

        // POST api/<RepairController>
        [HttpPost]
        public void Post([FromBody] RepairDto repair)
        {
            try
            {
                _logger.LogInformation("Received new repair");
                _rabbitMqProducer.SendRepairMessage(repair);
                _logger.LogInformation("Registered new repair");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error receiving and storing new repair");
            }
        }
    }
}
