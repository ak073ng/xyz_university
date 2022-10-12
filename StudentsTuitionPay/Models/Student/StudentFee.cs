namespace StudentsTuitionPay.Models.Student
{
    public class StudentFee
    {
        public long Id { get; set; }
        public int StudentId { get; set; }
        public int FeeId { get; set; }
        public int AmountPaid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
