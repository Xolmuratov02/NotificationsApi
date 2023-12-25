using NotificationsApi.Domain.Entities;
using NotificationsApi.Persistence.DataContexts;
using NotificationsApi.Persistence.Repositories.Interfaces;

namespace NotificationsApi.Persistence.Repositories;

public class UserSettingsRepository : EntityRepositoryBase<UserSettings, NotificationDbContext>, IUserSettingsRepository
{
    public UserSettingsRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }

    public ValueTask<UserSettings?> GetByIdAsync(
        Guid userId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    ) =>
        base.GetByIdAsync(userId, asNoTracking, cancellationToken);
}