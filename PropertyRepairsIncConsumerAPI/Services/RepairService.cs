using PropertyRepairsIncConsumerAPI.Data;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using PropertyRepairsIncCommon.DTOs;
using PropertyRepairsIncConsumerAPI.Models;
using Newtonsoft.Json;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PropertyRepairsIncConsumerAPI.Services
{
    public class RepairService : IRepairService
    {
        private readonly PropertyRepairsDbContext _context;
        private readonly ILogger<RepairService> _logger;

        public RepairService(PropertyRepairsDbContext context, ILogger<RepairService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<RepairDto>> GetAll()
        {
            _logger.LogInformation("Got a request to return repairs");
            List<Repair> list = await _context.Repairs.ToListAsync();

            _logger.LogInformation("Have retreived {n} repairs", list.Count);

            List<RepairDto> repairs = new List<RepairDto>();
            foreach (Repair item in list)
            {
                repairs.Add(item.ConvertToRepairDto());
            }

            return repairs;
        }

        public async Task<IEnumerable<RepairDto>> GetRepairForSpecificHouse(int houseId)
        {
            _logger.LogInformation("Got a request to return repairs by house");
            List<Repair> list = await _context.Repairs.Where(p => p.HouseId == houseId).ToListAsync();

            _logger.LogInformation("Have retreived {n} repairs", list.Count);

            List<RepairDto> repairs = new List<RepairDto>();
            foreach (Repair item in list)
            {
                repairs.Add(item.ConvertToRepairDto());
            }

            return repairs;
        }

        public async Task StoreNewRepair(RepairDto repairDto)
        {
            _logger.LogInformation("Received RepairDTO from RabbitMQ");
            Repair repair = repairDto.ConvertToRepair();
            repair.HouseId = 1;

            _context.Add(repair);
            _context.SaveChangesAsync();
        }

        public async Task ReadAndStoreRepairMessages()
        {
            //Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
            var factory = new ConnectionFactory { HostName = "localhost" };

            //Create the RabbitMQ connection using connection factory details as i mentioned above
            var connection = factory.CreateConnection();
            //Here we create channel with session and model
            using var channel = connection.CreateModel();
            //declare the queue after mentioning name and a few property related to that
            channel.QueueDeclare("repair",
                                 //  durable: true,
                                 exclusive: false,
                                 autoDelete: false
                );

            //Set Event object which listen message from chanel which is sent by producer
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();

                _logger.LogInformation("Received message from RabbitMQ");

                var message = Encoding.UTF8.GetString(body);
                //Console.WriteLine($"Repair message received: {message}");
                RepairDto? repairDto = JsonConvert.DeserializeObject<RepairDto>(message);
                                
                if (repairDto != null)
                {
                    await StoreNewRepair(repairDto);
                }
                else
                {
                    _logger.LogInformation("Received empty RepairDTO from RabbitMQ");
                }
            };
            //read the message
            channel.BasicConsume(queue: "repair", autoAck: true, consumer: consumer);
            //Console.ReadKey();
        }
    }
}
