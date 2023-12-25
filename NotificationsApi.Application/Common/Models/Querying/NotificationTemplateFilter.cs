using NotificationsApi.Domain.Enums;

namespace NotificationsApi.Application.Common.Models.Querying;

public class NotificationTemplateFilter : FilterPagination
{
    public IList<NotificationType> TemplateType { get; set; }
}