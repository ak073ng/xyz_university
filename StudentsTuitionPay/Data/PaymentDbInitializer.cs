using StudentsTuitionPay.Models.Payment.Utility;
using StudentsTuitionPay.Models.Payment;

namespace StudentsTuitionPay.Data
{
    public class PaymentDbInitializer
    {
        public static void InitializeModelsInDb(PaymentDbContext context)
        {
            InitializeChannels(context);            
            InitializePaymentOptions(context);
            InitializePaymentNotifications(context);
        }

        private static void InitializePaymentNotifications(PaymentDbContext context)
        {
            var PaymentNotifications = new PaymentNotification[]
            {
                new PaymentNotification
                {
                    Id = 1,
                    StudentId = 123456,
                    PaymentOptionId = 2,
                    ChannelId = 2,
                    Amount = 12000,
                    TransactionCode = "X12345678910",
                    FromInstitution = "Family Bank",
                    ToInstitution = "XYZ University",
                    CreatedAt = Convert.ToDateTime("2021/06/18"),
                    UpdatedAt = Convert.ToDateTime("2021/08/04"),
                },
                new PaymentNotification
                {
                    Id = 2,
                    StudentId = 789101,
                    PaymentOptionId = 1,
                    ChannelId = 1,
                    Amount = 1200,
                    TransactionCode = "X32145678910",
                    FromInstitution = "Family Bank",
                    ToInstitution = "XYZ University",
                    CreatedAt = Convert.ToDateTime("2020/01/06"),
                    UpdatedAt = Convert.ToDateTime("2020/02/19"),
                },
                new PaymentNotification
                {
                    Id = 3,
                    StudentId = 127452,
                    PaymentOptionId = 3,
                    ChannelId = 4,
                    Amount = 7600,
                    TransactionCode = "X12365478910",
                    FromInstitution = "Family Bank",
                    ToInstitution = "XYZ University",
                    CreatedAt = Convert.ToDateTime("2021/07/17"),
                    UpdatedAt = Convert.ToDateTime("2021/08/01"),
                },
                new PaymentNotification
                {
                    Id = 4,
                    StudentId = 328765,
                    PaymentOptionId = 4,
                    ChannelId = 3,
                    Amount = 64300,
                    TransactionCode = "X12345698710",
                    FromInstitution = "Family Bank",
                    ToInstitution = "XYZ University",
                    CreatedAt = Convert.ToDateTime("2020/12/11"),
                    UpdatedAt = Convert.ToDateTime("2021/04/28"),
                },
                new PaymentNotification
                {
                    Id = 5,
                    StudentId = 311765,
                    PaymentOptionId = 2,
                    ChannelId = 2,
                    Amount = 180000,
                    TransactionCode = "X12345678019",
                    FromInstitution = "Family Bank",
                    ToInstitution = "XYZ University",
                    CreatedAt = Convert.ToDateTime("2020/12/12"),
                    UpdatedAt = Convert.ToDateTime("2021/11/30"),
                },
            };

            context.PaymentNotifications.AddRange(PaymentNotifications);
            context.SaveChanges();
        }

        private static void InitializeChannels(PaymentDbContext context)
        {
            var Channels = new Channel[]
            {
                new Channel
                {
                    Id = 1,
                    Name = "ATM",
                    CreatedAt = Convert.ToDateTime("2021/06/18"),
                    UpdatedAt = Convert.ToDateTime("2021/08/04"),
                },
                new Channel
                {
                    Id = 2,
                    Name = "Mobile Money",
                    CreatedAt = Convert.ToDateTime("2020/01/06"),
                    UpdatedAt = Convert.ToDateTime("2020/02/19"),
                },
                new Channel
                {
                    Id = 3,
                    Name = "Branch",
                    CreatedAt = Convert.ToDateTime("2021/07/17"),
                    UpdatedAt = Convert.ToDateTime("2021/08/01"),
                },
                new Channel
                {
                    Id = 4,
                    Name = "Online",
                    CreatedAt = Convert.ToDateTime("2020/12/11"),
                    UpdatedAt = Convert.ToDateTime("2021/04/28"),
                },
            };

            context.Channels.AddRange(Channels);
            context.SaveChanges();
        }

        private static void InitializePaymentOptions(PaymentDbContext context)
        {
            var PaymentOptions = new PaymentOption[]
            {
                new PaymentOption
                {
                    Id = 1,
                    Name = "Direct Debit",
                    CreatedAt = Convert.ToDateTime("2021/06/18"),
                    UpdatedAt = Convert.ToDateTime("2021/08/04"),
                },
                new PaymentOption
                {
                    Id = 2,
                    Name = "Mobile Money",
                    CreatedAt = Convert.ToDateTime("2020/01/06"),
                    UpdatedAt = Convert.ToDateTime("2020/02/19"),
                },
                new PaymentOption
                {
                    Id = 3,
                    Name = "Electronic Bank Transfer",
                    CreatedAt = Convert.ToDateTime("2021/07/17"),
                    UpdatedAt = Convert.ToDateTime("2021/08/01"),
                },
                new PaymentOption
                {
                    Id = 4,
                    Name = "Cheque",
                    CreatedAt = Convert.ToDateTime("2020/12/11"),
                    UpdatedAt = Convert.ToDateTime("2021/04/28"),
                },
                new PaymentOption
                {
                    Id = 5,
                    Name = "Cash",
                    CreatedAt = Convert.ToDateTime("2020/12/11"),
                    UpdatedAt = Convert.ToDateTime("2021/04/28"),
                },
            };

            context.PaymentOptions.AddRange(PaymentOptions);
            context.SaveChanges();
        }
    }
}
