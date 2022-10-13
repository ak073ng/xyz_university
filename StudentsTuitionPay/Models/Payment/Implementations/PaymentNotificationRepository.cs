using Microsoft.EntityFrameworkCore;
using StudentsTuitionPay.Models.Payment.Interfaces;
using StudentsTuitionPay.Models.Payment.Utility;

namespace StudentsTuitionPay.Models.Payment.Implementations
{
    public class PaymentNotificationRepository : IPaymentNotifRepository
    {
        private readonly PaymentDbContext DbContext;

        public async Task<IEnumerable<PaymentNotification>> PaymentNotifications()
        {
            var List = await DbContext.PaymentNotifications.Select(
                p => new PaymentNotification
                {
                    Id = p.Id,
                    StudentId = p.StudentId,
                    PaymentOptionId = p.PaymentOptionId,
                    ChannelId = p.ChannelId,
                    Amount = p.Amount,
                    TransactionCode = p.TransactionCode,
                    FromInstitution = p.FromInstitution,
                    ToInstitution = p.ToInstitution,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt
                }
            ).ToListAsync();

            return List;
        }

        public async Task<PaymentNotification> getPaymentNotificationById(int id)
        {
            PaymentNotification PaymentNotification = await DbContext.PaymentNotifications.Select(
                p => new PaymentNotification
                {
                    Id = p.Id,
                    StudentId = p.StudentId,
                    PaymentOptionId = p.PaymentOptionId,
                    ChannelId = p.ChannelId,
                    Amount = p.Amount,
                    TransactionCode = p.TransactionCode,
                    FromInstitution = p.FromInstitution,
                    ToInstitution = p.ToInstitution,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt
                }
            ).FirstOrDefaultAsync(s => s.Id == id);

            return PaymentNotification;
        }

        public async Task<PaymentNotification> AddPaymentNotif(PaymentNotification paymentNotif)
        {
            var PaymentNotification = new PaymentNotification()
            {
                StudentId = paymentNotif.StudentId,
                PaymentOptionId = paymentNotif.PaymentOptionId,
                ChannelId = paymentNotif.ChannelId,
                Amount = paymentNotif.Amount,
                TransactionCode = paymentNotif.TransactionCode,
                FromInstitution = paymentNotif.FromInstitution,
                ToInstitution = paymentNotif.ToInstitution,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            DbContext.PaymentNotifications.Add(PaymentNotification);

            await DbContext.SaveChangesAsync();

            return PaymentNotification;
        }

        public async Task<PaymentNotification> UpdatePaymentNotif(PaymentNotification paymentNotif)
        {
            var PaymentNotification = await DbContext.PaymentNotifications.FirstOrDefaultAsync(p => p.Id == paymentNotif.Id);

            if (PaymentNotification != null)
            {
                PaymentNotification.StudentId = paymentNotif.StudentId;
                PaymentNotification.PaymentOptionId = paymentNotif.PaymentOptionId;
                PaymentNotification.ChannelId = paymentNotif.ChannelId;
                PaymentNotification.Amount = paymentNotif.Amount;
                PaymentNotification.TransactionCode = paymentNotif.TransactionCode;
                PaymentNotification.FromInstitution = paymentNotif.FromInstitution;
                PaymentNotification.ToInstitution = paymentNotif.ToInstitution;
                PaymentNotification.UpdatedAt = DateTime.Now;

                await DbContext.SaveChangesAsync();
            }

            return PaymentNotification;
        }
        public async Task DeletePaymentNotif(int id)
        {
            var PaymentNotification = new PaymentNotification() { Id = id };

            DbContext.PaymentNotifications.Attach(PaymentNotification);

            DbContext.PaymentNotifications.Remove(PaymentNotification);

            await DbContext.SaveChangesAsync();
        }
    }
}
