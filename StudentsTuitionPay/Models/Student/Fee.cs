namespace StudentsTuitionPay.Models.Student
{
    public class Fee
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Semester { get; set; }
        public int Amount { get; set; }
        public long CourseId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
