using NotificationsApi.Domain.Enums;

namespace NotificationsApi.Application.Common.Notifications.Models;

public class EmailNotificationRequest : NotificationRequest
{
    public EmailNotificationRequest() => Type = NotificationType.Email;

    // attachments etc.
}