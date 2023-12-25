using NotificationsApi.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotificationsApi.Domain.Entities;

public class SmsHistory : NotificationHistory
{
    public SmsHistory()
    {
        Type = NotificationType.Sms;
    }

    public string SenderPhoneNumber { get; set; } = default!;

    public string ReceiverPhoneNumber { get; set; } = default!;

    [NotMapped]
    public SmsTemplate SmsTemplate
    {
        get => Template is not null ? Template as SmsTemplate : null;
        set => Template = value;
    }
}