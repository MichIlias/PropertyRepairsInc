using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace PropertyRepairsIncPublisherAPI.Rabbit
{
    public class RabbitMqProducer : IRabbitMqProducer
    {
        private readonly ILogger<RabbitMqProducer> _logger;

        public RabbitMqProducer(ILogger<RabbitMqProducer> logger)
        {
            _logger = logger;
        }

        public void SendRepairMessage<T>(T message)
        {
            //Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
            var factory = new ConnectionFactory { HostName = "localhost" };

            //Create the RabbitMQ connection using connection factory details as i mentioned above
            var connection = factory.CreateConnection();
            _logger.LogInformation("Created new RabbitMQ connection");

            //Here we create channel with session and model
            using var channel = connection.CreateModel();
            _logger.LogInformation("Created new RabbitMQ model");
            //declare the queue after mentioning name and a few property related to that
            channel.QueueDeclare(queue: "repair",
                         //   durable: true,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);


            //Serialize the message
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            //put the data on to the product queue
            channel.BasicPublish(exchange: string.Empty, routingKey: "repair", body: body);

            _logger.LogInformation("PUblished new RabbitMQ message");
        }
    }
}
