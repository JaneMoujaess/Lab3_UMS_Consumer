using NotificationCenter_Lab3_MicroservicesPractice.Models;

namespace NotificationCenter_Lab3_MicroservicesPractice.Services;

public interface INotificationService
{
    Task<List<Notification>> ConsumeNotification();
}