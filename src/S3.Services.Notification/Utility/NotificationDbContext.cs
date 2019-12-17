using Microsoft.EntityFrameworkCore;
using S3.Services.Notification.Domain;

namespace S3.Services.Notification.Utility
{
    public class NotificationDbContext : DbContext
    {
        public NotificationDbContext(DbContextOptions<NotificationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Apply custum configurations using reflextion to scan for configuration files
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Startup).Assembly);
        }
    }
}
