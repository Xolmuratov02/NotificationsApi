﻿using FluentValidation;
using NotificationsApi.Application.Common.Notifications.Brokers;
using NotificationsApi.Application.Common.Notifications.Models;
using NotificationsApi.Application.Common.Notifications.Services;
using NotificationsApi.Domain.Enums;
using NotificationsApi.Domain.Extensions;

namespace NotificationsApi.Infrastructure.Common.Notifications.Services;

public class EmailSenderService : IEmailSenderService
{
    private readonly IEnumerable<IEmailSenderBroker> _emailSenderBrokers;
    private readonly IValidator<EmailMessage> _emailMessageValidator;

    public EmailSenderService(
        IEnumerable<IEmailSenderBroker> emailSenderBrokers,
        IValidator<EmailMessage> emailMessageValidator
    )
    {
        _emailSenderBrokers = emailSenderBrokers;
        _emailMessageValidator = emailMessageValidator;
    }

    public async ValueTask<bool> SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default)
    {
        var validationResult = _emailMessageValidator.Validate(emailMessage,
            options => options.IncludeRuleSets(NotificationEvent.OnSending.ToString()));
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        foreach (var smsSenderBroker in _emailSenderBrokers)
        {
            var sendNotificationTask = () => smsSenderBroker.SendAsync(emailMessage, cancellationToken);
            var result = await sendNotificationTask.GetValueAsync();

            emailMessage.IsSuccessful = result.IsSuccess;
            emailMessage.ErrorMessage = result.Exception?.Message;
            return result.IsSuccess;
        }

        return false;
    }
}