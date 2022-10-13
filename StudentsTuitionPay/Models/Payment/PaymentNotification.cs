namespace StudentsTuitionPay.Models.Payment
{
    public class PaymentNotification
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int PaymentOptionId { get; set; }
        public int ChannelId { get; set; }
        public int Amount { get; set; }
        public string TransactionCode { get; set; }
        public string FromInstitution { get; set; }
        public string ToInstitution { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
