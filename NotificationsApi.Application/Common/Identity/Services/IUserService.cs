﻿using NotificationsApi.Domain.Entities;

namespace NotificationsApi.Application.Common.Identity.Services;

public interface IUserService
{
    ValueTask<IList<User>> GetByIdsAsync(
    IEnumerable<Guid> usersId,
    bool asNoTracking = false,
    CancellationToken cancellationToken = default
);

    ValueTask<User?> GetSystemUserAsync(bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<User?> GetByIdAsync(
        Guid userId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    );
}