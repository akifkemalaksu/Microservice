using MassTransit;
using Microservice.CrossCuttingLayer;

Console.Title = "Notification";

var bus = Bus.Factory.CreateUsingRabbitMq(config =>
{
    config.Host(new Uri(RabbitMqConsts.RabbitMqRootUri), host =>
    {
        host.Username(RabbitMqConsts.UserName);
        host.Password(RabbitMqConsts.Password);
    });
    config.ReceiveEndpoint("todoQueue", endPoint =>
    {
        endPoint.PrefetchCount = 16;
        endPoint.UseMessageRetry(r => r.Interval(2, 100));
        endPoint.Consumer<TodoConsumerNotification>();
    });
});

bus.StartAsync();

Console.WriteLine(@"
    Listening for Todo registered events...
    Press enter to exit.
");
Console.ReadLine();

bus.StopAsync();