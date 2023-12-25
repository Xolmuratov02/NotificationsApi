using FluentValidation;
using NotificationsApi.Application.Common.Notifications.Brokers;
using NotificationsApi.Application.Common.Notifications.Models;
using NotificationsApi.Application.Common.Notifications.Services;
using NotificationsApi.Domain.Enums;
using NotificationsApi.Domain.Extensions;

namespace NotificationsApi.Infrastructure.Common.Notifications.Services;

public class SmsSenderService : ISmsSenderService
{
    private readonly IEnumerable<ISmsSenderBroker> _smsSenderBrokers;
    private readonly IValidator<SmsMessage> _smsMessageValidator;

    public SmsSenderService(
        IEnumerable<ISmsSenderBroker> smsSenderBrokers,
        IValidator<SmsMessage> smsMessageValidator
    )
    {
        _smsSenderBrokers = smsSenderBrokers;
        _smsMessageValidator = smsMessageValidator;
    }

    public async ValueTask<bool> SendAsync(SmsMessage smsMessage, CancellationToken cancellationToken = default)
    {
        var validationResult = _smsMessageValidator.Validate(smsMessage,
            options => options.IncludeRuleSets(NotificationEvent.OnRendering.ToString()));
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        foreach (var smsSenderBroker in _smsSenderBrokers)
        {
            var sendNotificationTask = () => smsSenderBroker.SendAsync(smsMessage, cancellationToken);
            var result = await sendNotificationTask.GetValueAsync();

            smsMessage.IsSuccessful = result.IsSuccess;
            smsMessage.ErrorMessage = result.Exception?.Message;
            return result.IsSuccess;
        }

        return false;
    }
}