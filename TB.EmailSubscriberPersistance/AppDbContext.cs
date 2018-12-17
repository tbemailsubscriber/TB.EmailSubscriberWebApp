using Microsoft.EntityFrameworkCore;
using TB.EmailSubscriber.Models;

namespace TB.EmailSubscriber.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Topic> Topics { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubscribtionTopic>().HasKey(est =>
              new { est.SubscriptionId, est.TopicId });

            modelBuilder.Entity<Subscription>().HasIndex(s => s.Email).IsUnique();
        }



    }
}
