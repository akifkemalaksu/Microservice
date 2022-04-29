using MassTransit;
using Microservice.CrossCuttingLayer;

namespace Microservice.Consumers.Consumers
{
    public class TodoConsumer : IConsumer<Todo>
    {
        public Task Consume(ConsumeContext<Todo> context)
        {
            var data = context.Message;
            return default;
        }
    }
}