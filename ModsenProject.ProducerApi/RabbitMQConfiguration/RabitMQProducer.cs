using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace ModsenProject.ProducerApi.RabbitMQConfiguration
{
    public class RabitMQProducer : IRabitMQProducer
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "rabbitmq",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("message", exclusive: false, autoDelete: false);
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "", routingKey: "message", body: body);
        }
    }
}
