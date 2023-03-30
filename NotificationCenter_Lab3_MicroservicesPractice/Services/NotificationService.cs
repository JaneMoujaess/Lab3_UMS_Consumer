using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using NotificationCenter_Lab3_MicroservicesPractice.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace NotificationCenter_Lab3_MicroservicesPractice.Services;

public class NotificationService:INotificationService
{
    private readonly NotificationCenterContext _dbContext;

    public NotificationService(NotificationCenterContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Notification>> ConsumeNotification()
    {
        return await _dbContext.Notifications.ToListAsync();
    }
}