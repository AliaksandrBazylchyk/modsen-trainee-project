namespace ModsenProject.ConsumerApi.RabbitMQConfiguration
{
    public interface IRabbitMQConsumer
    {
        void EnqueueFromMessageQueue();
    }
}
