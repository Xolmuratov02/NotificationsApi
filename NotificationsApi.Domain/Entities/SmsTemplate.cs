using Type = NotificationsApi.Domain.Enums.NotificationType;


namespace NotificationsApi.Domain.Entities;

public class SmsTemplate : NotificationTemplate
{
    public SmsTemplate()
    {
        Type = Type.Sms;
    }
}