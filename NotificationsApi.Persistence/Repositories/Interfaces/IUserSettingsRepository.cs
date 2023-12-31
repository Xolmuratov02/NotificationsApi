﻿using NotificationsApi.Domain.Entities;

namespace NotificationsApi.Persistence.Repositories.Interfaces;

public interface IUserSettingsRepository
{
    ValueTask<UserSettings?> GetByIdAsync(
        Guid userId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    );
}