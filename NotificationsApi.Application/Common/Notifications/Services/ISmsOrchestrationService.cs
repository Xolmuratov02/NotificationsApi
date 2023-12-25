using NotificationsApi.Application.Common.Notifications.Models;
using NotificationsApi.Domain.Common.Exceptions;

namespace NotificationsApi.Application.Common.Notifications.Services;

public interface ISmsOrchestrationService
{
    ValueTask<FuncResult<bool>> SendAsync(
        SmsNotificationRequest request,
        CancellationToken cancellationToken = default
    );
}