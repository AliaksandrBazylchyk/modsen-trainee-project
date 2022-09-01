using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModsenProject.ConsumerApi.RabbitMQConfiguration;

namespace ModsenProject.ConsumerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumeController : ControllerBase
    {
        private readonly IRabbitMQConsumer _rabbitMqConsumer;

        public ConsumeController(IRabbitMQConsumer rabbitMqConsumer)
        {
            _rabbitMqConsumer = rabbitMqConsumer;
        }

        [HttpGet]
        public async Task<IActionResult> DebugLastMessageAsync()
        {
            _rabbitMqConsumer.EnqueueFromMessageQueue();
            return Ok("Done. Check debug console! ");
        }
    }
}
