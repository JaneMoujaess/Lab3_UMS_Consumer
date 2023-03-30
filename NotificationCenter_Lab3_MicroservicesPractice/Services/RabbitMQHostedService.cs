using System.Text;
using System.Text.Json;
using NotificationCenter_Lab3_MicroservicesPractice.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace NotificationCenter_Lab3_MicroservicesPractice.Services;

public class RabbitMQHostedService : IHostedService
{
    private IConnection _connection;
    private IModel _channel;
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var factory = new ConnectionFactory { HostName = "localhost" }; 
        _connection = factory.CreateConnection(); 
        _channel = _connection.CreateModel();
        _channel.QueueDeclare("notifications",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += async (model, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine("listening...");
            Console.WriteLine(message);
            var notification = JsonSerializer.Deserialize<Notification>(message);

            await using (var dbContext = new NotificationCenterContext())
            {
                dbContext.Notifications.Add(notification);
                await dbContext.SaveChangesAsync();
            }
            Console.WriteLine("added notif");
        };
        _channel.BasicConsume(queue: "notifications", autoAck: true, consumer: consumer);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _connection.Close();
        return Task.CompletedTask;
    }
}