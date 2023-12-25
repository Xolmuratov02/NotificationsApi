using NotificationsApi.Domain.Entities;
using NotificationsApi.Persistence.DataContexts;
using NotificationsApi.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace NotificationsApi.Persistence.Repositories;

public class EmailTemplateRepository : EntityRepositoryBase<EmailTemplate, NotificationDbContext>,
    IEmailTemplateRepository
{
    public EmailTemplateRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<EmailTemplate> Get(
        Expression<Func<EmailTemplate, bool>>? predicate = default,
        bool asNoTracking = false
    ) =>
        base.Get(predicate, asNoTracking);

    public ValueTask<EmailTemplate> CreateAsync(
        EmailTemplate emailTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    ) =>
        base.CreateAsync(emailTemplate, saveChanges, cancellationToken);
}