using FluentValidation;
using NotificationsApi.Application.Common.Models.Querying;
using NotificationsApi.Application.Common.Notifications.Services;
using NotificationsApi.Domain.Entities;
using NotificationsApi.Domain.Enums;

namespace NotificationsApi.Infrastructure.Common.Notifications.Services;

public class EmailHistoryService : IEmailHistoryService
{
    private readonly IEmailHistoryRepository _emailHistoryRepository;
    private readonly IValidator<EmailHistory> _emailHistoryValidator;

    public EmailHistoryService(IEmailHistoryRepository emailHistoryRepository, IValidator<EmailHistory> emailHistoryValidator)
    {
        _emailHistoryRepository = emailHistoryRepository;
        _emailHistoryValidator = emailHistoryValidator;
    }

    public async ValueTask<IList<EmailHistory>> GetByFilterAsync(
        FilterPagination paginationOptions,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    ) =>
        await _emailHistoryRepository.Get().ApplyPagination(paginationOptions).ToListAsync(cancellationToken);

    public async ValueTask<EmailHistory> CreateAsync(
        EmailHistory emailHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    )
    {
        var validationResult = await _emailHistoryValidator.ValidateAsync(emailHistory,
            options => options.IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken);
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        return await _emailHistoryRepository.CreateAsync(emailHistory, saveChanges, cancellationToken);
    }
}