using NotificationsApi.Application.Common.Notifications.Models;

namespace NotificationsApi.Application.Common.Notifications.Brokers;

public interface IEmailSenderBroker
{
    ValueTask<bool> SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default);
}