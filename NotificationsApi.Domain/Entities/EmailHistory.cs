﻿using NotificationsApi.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotificationsApi.Domain.Entities;

public class EmailHistory : NotificationHistory
{
    public EmailHistory()
    {
        Type = NotificationType.Email;
    }

    public string SendEmailAddress { get; set; } = default!;

    public string ReceiverEmailAddress { get; set; } = default!;

    public string Subject { get; set; } = default!;

    [NotMapped]
    public EmailTemplate EmailTemplate
    {
        get => Template is not null ? Template as EmailTemplate : null;
        set => Template = value;
    }
}