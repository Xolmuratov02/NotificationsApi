using NotificationsApi.Domain.Entities;
using System.Linq.Expressions;

namespace NotificationsApi.Persistence.Repositories.Interfaces;

public interface IUserRepository
{
    IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<IList<User>> GetByIdsAsync(
        IEnumerable<Guid> usersId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    );

    ValueTask<User?> GetByIdAsync(
        Guid userId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    );
}