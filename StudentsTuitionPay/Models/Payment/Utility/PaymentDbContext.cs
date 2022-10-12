using Microsoft.EntityFrameworkCore;

namespace StudentsTuitionPay.Models.Payment.Utility
{
    public class PaymentDbContext: DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
        {
        }

        public DbSet<Channel> Channels { get; set; }
        public DbSet<PaymentOption> PaymentOptions { get; set; }
        public DbSet<PaymentNotification> PaymentNotifications { get; set; }
    }
}
