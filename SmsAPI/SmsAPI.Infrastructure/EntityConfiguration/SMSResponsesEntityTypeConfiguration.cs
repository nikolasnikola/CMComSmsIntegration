using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsAPI.Domain.Models;
using System;

namespace SmsAPI.Infrastructure.EntityConfiguration
{
    public class SMSResponsesEntityTypeConfiguration : IEntityTypeConfiguration<SMSResponse>
    {
        public void Configure(EntityTypeBuilder<SMSResponse> builder)
        {
            GuardBuilder(builder);
            builder.HasKey(c => c.Id);
        }
        private static void GuardBuilder(EntityTypeBuilder<SMSResponse> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
        }
    }
}
