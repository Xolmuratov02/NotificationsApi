using Type = NotificationsApi.Domain.Enums.NotificationType;


namespace NotificationsApi.Domain.Entities;

public class EmailTemplate : NotificationTemplate
{
    public EmailTemplate()
    {
        Type = Type.Email;
    }

    public string Subject { get; set; } = default!;
}