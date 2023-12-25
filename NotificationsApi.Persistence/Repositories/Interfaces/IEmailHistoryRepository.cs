using NotificationsApi.Domain.Entities;
using System.Linq.Expressions;

namespace NotificationsApi.Persistence.Repositories.Interfaces;

public interface IEmailHistoryRepository
{
    IQueryable<EmailHistory> Get(
        Expression<Func<EmailHistory, bool>>? predicate = default,
        bool asNoTracking = false
    );

    ValueTask<EmailHistory> CreateAsync(
        EmailHistory emailHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}