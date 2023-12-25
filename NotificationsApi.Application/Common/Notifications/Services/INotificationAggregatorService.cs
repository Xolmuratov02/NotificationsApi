using NotificationsApi.Application.Common.Models.Querying;
using NotificationsApi.Application.Common.Notifications.Models;
using NotificationsApi.Domain.Common.Exceptions;
using NotificationsApi.Domain.Entities;

namespace NotificationsApi.Application.Common.Notifications.Services;

public interface INotificationAggregatorService
{
    ValueTask<FuncResult<bool>> SendAsync(
        NotificationRequest notificationRequest,
        CancellationToken cancellationToken = default
    );

    ValueTask<IList<NotificationTemplate>> GetTemplatesByFilterAsync(
        NotificationTemplateFilter filter,
        CancellationToken cancellationToken = default
    );
}