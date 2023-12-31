﻿using FluentValidation;
using NotificationsApi.Domain.Entities;
using NotificationsApi.Domain.Enums;

namespace NotificationsApi.Infrastructure.Common.Validators;

public class SmsHistoryValidator : AbstractValidator<SmsHistory>
{
    public SmsHistoryValidator()
    {
        RuleSet(EntityEvent.OnCreate.ToString(),
            () =>
            {
                RuleFor(history => history.TemplateId).NotEqual(Guid.Empty);

                RuleFor(history => history.SenderUserId).NotEqual(Guid.Empty);

                RuleFor(history => history.ReceiverUserId).NotEqual(Guid.Empty);

                RuleFor(history => history.Content).NotEmpty().MaximumLength(129_536);

                RuleFor(history => history.ErrorMessage).NotNull().NotEmpty().When(history => !history.IsSuccessful);

                RuleFor(history => history.SenderPhoneNumber).NotEmpty().MaximumLength(64);

                RuleFor(history => history.ReceiverPhoneNumber).NotEmpty().MaximumLength(64);
            });
    }
}