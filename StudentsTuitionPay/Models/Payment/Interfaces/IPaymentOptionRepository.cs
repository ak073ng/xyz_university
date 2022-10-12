namespace StudentsTuitionPay.Models.Payment.Interfaces
{
    public interface IPaymentOptionRepository
    {
        Task<IEnumerable<PaymentOption>> PaymentOptions();
        Task<PaymentOption> getPaymentOptionById (int id);
        Task<PaymentOption> AddPaymentOption(PaymentOption paymentOption);
        Task<PaymentOption> UpdatePaymentOption(PaymentOption paymentOption);
        Task DeletePaymentOption(int id);
    }
}
