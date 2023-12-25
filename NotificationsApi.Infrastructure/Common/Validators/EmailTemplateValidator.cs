﻿using FluentValidation;
using NotificationsApi.Domain.Entities;
using NotificationsApi.Domain.Enums;

namespace NotificationsApi.Infrastructure.Common.Validators;

public class EmailTemplateValidator : AbstractValidator<EmailTemplate>
{
    public EmailTemplateValidator()
    {
        RuleFor(template => template.Content)
            .NotEmpty()
            // .WithMessage("Sms template content is required")
            .MinimumLength(10)
            // .WithMessage("Sms template content must be at least 10 characters long")
            .MaximumLength(256);
        // .WithMessage("Sms template content must be at most 256 characters long");

        RuleFor(template => template.Type)
            .Equal(NotificationType.Email);
        // .WithMessage("Sms template notification type must be Sms");
    }
}