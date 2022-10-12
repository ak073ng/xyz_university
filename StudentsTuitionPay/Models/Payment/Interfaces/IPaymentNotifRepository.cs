namespace StudentsTuitionPay.Models.Payment.Interfaces
{
    public interface IPaymentNotifRepository
    {
        Task<IEnumerable<PaymentNotification>> PaymentNotifications();
        Task<PaymentNotification> getPaymentNotificationById(int id);
        Task<PaymentNotification> AddPaymentNotif(PaymentNotification paymentNotif);
        Task<PaymentNotification> UpdatePaymentNotif(PaymentNotification paymentNotif);
        Task DeletePaymentNotif(int id);
    }
}
