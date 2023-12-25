using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NotificationsApi.Application.Common.Models.Querying;
using NotificationsApi.Application.Common.Notifications.Services;
using NotificationsApi.Application.Common.Querying.Extensions;
using NotificationsApi.Domain.Entities;
using NotificationsApi.Domain.Enums;
using NotificationsApi.Persistence.Repositories.Interfaces;

namespace NotificationsApi.Infrastructure.Common.Notifications.Services;

public class SmsHistoryService : ISmsHistoryService
{
    private readonly ISmsHistoryRepository _smsHistoryRepository;
    private readonly IValidator<SmsHistory> _smsHistoryValidator;

    public SmsHistoryService(ISmsHistoryRepository smsHistoryRepository, IValidator<SmsHistory> smsHistoryValidator)
    {
        _smsHistoryRepository = smsHistoryRepository;
        _smsHistoryValidator = smsHistoryValidator;
    }

    public async ValueTask<IList<SmsHistory>> GetByFilterAsync(
        FilterPagination paginationOptions,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    ) =>
        await _smsHistoryRepository.Get().ApplyPagination(paginationOptions).ToListAsync(cancellationToken);

    public async ValueTask<SmsHistory> CreateAsync(
        SmsHistory smsHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    )
    {
        var validationResult = await _smsHistoryValidator.ValidateAsync(smsHistory,
            options => options.IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken);
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        return await _smsHistoryRepository.CreateAsync(smsHistory, saveChanges, cancellationToken);
    }
}