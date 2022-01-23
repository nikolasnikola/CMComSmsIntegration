using Microsoft.EntityFrameworkCore;
using SmsAPI.Domain.Models;
using SmsAPI.Infrastructure.EntityConfiguration;

namespace SmsAPI.Infrastructure
{
    public class SMSApiContext : DbContext
    {
        public SMSApiContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<SMSResponse> SMSResponses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new SMSResponsesEntityTypeConfiguration());
        }
    }
}
