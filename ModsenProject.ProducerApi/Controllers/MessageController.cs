using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModsenProject.ProducerApi.Models;
using ModsenProject.ProducerApi.RabbitMQConfiguration;

namespace ModsenProject.ProducerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IRabitMQProducer _rabitMQProducer;

        public MessageController(
            IRabitMQProducer rabitMQProducer
            )
        {
            _rabitMQProducer = rabitMQProducer;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessageBusAsync([FromBody] MessageBusModel model)
        {
            _rabitMQProducer.SendMessage(model);
            return Ok("Done");
        }
    }
}
