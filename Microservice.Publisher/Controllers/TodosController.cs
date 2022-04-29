using MassTransit;
using Microservice.CrossCuttingLayer;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly IBus _bus;

        public TodosController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(Todo todo)
        {
            if (todo is not null)
            {
                Uri uri = new Uri(RabbitMqConsts.RabbitMqUri);
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(todo);

                return Ok();
            }

            return BadRequest();
        }
    }
}