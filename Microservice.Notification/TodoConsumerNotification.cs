using MassTransit;
using Microservice.CrossCuttingLayer;

public class TodoConsumerNotification : IConsumer<Todo>
{
    public async Task Consume(ConsumeContext<Todo> context)
    {
        await Console.Out.WriteLineAsync($"Notification sent: todo id {context.Message.Id}");
    }
}