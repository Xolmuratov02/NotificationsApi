using NotificationsApi.Application.Common.Notifications.Models;

namespace NotificationsApi.Application.Common.Notifications.Brokers;

public interface ISmsSenderBroker
{
    ValueTask<bool> SendAsync(SmsMessage smsMessage, CancellationToken cancellationToken = default);
}