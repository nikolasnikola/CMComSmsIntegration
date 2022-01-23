using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsAPI.Domain.Models;
using System;

namespace SmsAPI.Infrastructure.EntityConfiguration
{
    public class SMSResponsesEntityTypeConfiguration : IEntityTypeConfiguration<SMSResponses>
    {
        public void Configure(EntityTypeBuilder<SMSResponses> builder)
        {
            GuardBuilder(builder);
            builder.HasKey(c => c.Id);
        }
        private static void GuardBuilder(EntityTypeBuilder<SMSResponses> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
        }
    }
}
