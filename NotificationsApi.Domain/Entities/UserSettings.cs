using NotificationsApi.Domain.Common.Entities;
using NotificationsApi.Domain.Enums;

namespace NotificationsApi.Domain.Entities;

public class UserSettings : IEntity
{
    /// <summary>
    /// Gets or sets the user Id
    /// </summary>
    public Guid Id { get; set; }

    public NotificationType? PreferredNotificationType { get; set; }
}