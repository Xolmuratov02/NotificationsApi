using NotificationsApi.Domain.Entities;
using NotificationsApi.Persistence.DataContexts;
using NotificationsApi.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace NotificationsApi.Persistence.Repositories;

public class SmsTemplateRepository : EntityRepositoryBase<SmsTemplate, NotificationDbContext>, ISmsTemplateRepository
{
    public SmsTemplateRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<SmsTemplate> Get(
        Expression<Func<SmsTemplate, bool>>? predicate = default,
        bool asNoTracking = false
    ) =>
        base.Get(predicate, asNoTracking);

    public ValueTask<SmsTemplate> CreateAsync(
        SmsTemplate smsTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    ) =>
        base.CreateAsync(smsTemplate, saveChanges, cancellationToken);
}