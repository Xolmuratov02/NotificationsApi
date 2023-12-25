using NotificationsApi.Application.Common.Notifications.Models;

namespace NotificationsApi.Application.Common.Notifications.Services;

public interface IEmailSenderService
{
    ValueTask<bool> SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default);
}