using System.Text;
using Microsoft.AspNetCore.Mvc;
using NotificationCenter_Lab3_MicroservicesPractice.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace NotificationCenter_Lab3_MicroservicesPractice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationCenterController:ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationCenterController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }
    [HttpGet]
    public async Task<ActionResult<List<string>>> GetNotifications()
    {
        return Ok(await _notificationService.ConsumeNotification());
    }
}