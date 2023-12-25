using NotificationsApi.Application.Common.Notifications.Models;
using NotificationsApi.Domain.Common.Exceptions;

namespace NotificationsApi.Application.Common.Notifications.Services;

public interface IEmailOrchestrationService
{
    ValueTask<FuncResult<bool>> SendAsync(
        EmailNotificationRequest request,
        CancellationToken cancellationToken = default
    );
}