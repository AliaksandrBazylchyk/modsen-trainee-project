using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using System.Text;

namespace ModsenProject.ConsumerApi.RabbitMQConfiguration
{
    public class RabbitMQConsumer : IRabbitMQConsumer
    {
        public void EnqueueFromMessageQueue()
        {
            using var log = new LoggerConfiguration().WriteTo.Console().CreateLogger();

            var factory = new ConnectionFactory
            {
                HostName = "rabbitmq",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "message", durable: false, exclusive: false, autoDelete: false, arguments: null);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                log.Information($"Body received: {body}");
                var message = Encoding.UTF8.GetString(body);
                log.Information($"Message received: {message}");
            };

            channel.BasicConsume(queue: "message", autoAck: true, consumer: consumer);
        }
    }
}
