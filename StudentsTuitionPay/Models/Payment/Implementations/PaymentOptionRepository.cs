using Microsoft.EntityFrameworkCore;
using StudentsTuitionPay.Models.Payment.Interfaces;
using StudentsTuitionPay.Models.Payment.Utility;

namespace StudentsTuitionPay.Models.Payment.Implementations
{
    public class PaymentOptionRepository : IPaymentOptionRepository
    {
        private readonly PaymentDbContext DbContext;

        public async Task<IEnumerable<PaymentOption>> PaymentOptions()
        {
            var List = await DbContext.PaymentOptions.Select(
                p => new PaymentOption
                {
                    Id = p.Id,
                    Name = p.Name,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt
                }
            ).ToListAsync();

            return List;
        }

        public async Task<PaymentOption> getPaymentOptionById(int id)
        {
            PaymentOption PaymentOption = await DbContext.PaymentOptions.Select(
                p => new PaymentOption
                {
                    Id = p.Id,
                    Name = p.Name,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt
                }
            ).FirstOrDefaultAsync(p => p.Id == id);

            return PaymentOption;
        }

        public async Task<PaymentOption> AddPaymentOption(PaymentOption paymentOption)
        {
            var PaymentOption = new PaymentOption()
            {
                Name = paymentOption.Name,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            DbContext.PaymentOptions.Add(PaymentOption);

            await DbContext.SaveChangesAsync();

            return PaymentOption;
        }

        public async Task<PaymentOption> UpdatePaymentOption(PaymentOption paymentOption)
        {
            var PaymentOption = await DbContext.PaymentOptions.FirstOrDefaultAsync(p => p.Id == paymentOption.Id);

            if (PaymentOption != null)
            {
                PaymentOption.Name = paymentOption.Name;
                PaymentOption.UpdatedAt = DateTime.Now;

                await DbContext.SaveChangesAsync();
            }

            return PaymentOption;
        }
        public async Task DeletePaymentOption(int id)
        {
            var PaymentOption = new PaymentOption() { Id = id };

            DbContext.PaymentOptions.Attach(PaymentOption);

            DbContext.PaymentOptions.Remove(PaymentOption);

            await DbContext.SaveChangesAsync();
        }
    }
}
