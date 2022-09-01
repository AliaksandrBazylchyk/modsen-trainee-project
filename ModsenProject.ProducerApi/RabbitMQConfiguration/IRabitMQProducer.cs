namespace ModsenProject.ProducerApi.RabbitMQConfiguration
{
    public interface IRabitMQProducer
    {
        public void SendMessage<T>(T message);
    }
}
