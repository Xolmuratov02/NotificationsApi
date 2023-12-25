using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationsApi.Domain.Entities;

namespace NotificationsApi.Persistence.EntityConfigurations;

public class SmsTemplateConfiguration : IEntityTypeConfiguration<SmsTemplate>
{
    public void Configure(EntityTypeBuilder<SmsTemplate> builder)
    {
    }
}