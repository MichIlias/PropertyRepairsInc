namespace PropertyRepairsIncPublisherAPI.Rabbit
{
    public interface IRabbitMqProducer
    {
        void SendRepairMessage<T>(T message);
    }
}