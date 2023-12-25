using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationsApi.Domain.Entities;

namespace NotificationsApi.Persistence.EntityConfigurations;

public class SmsHistoryConfiguration : IEntityTypeConfiguration<SmsHistory>
{
    public void Configure(EntityTypeBuilder<SmsHistory> builder)
    {
        builder.Property(template => template.SenderPhoneNumber).IsRequired().HasMaxLength(32);
        builder.Property(template => template.ReceiverPhoneNumber).IsRequired().HasMaxLength(32);
    }
}