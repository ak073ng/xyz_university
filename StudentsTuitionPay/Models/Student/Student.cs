namespace StudentsTuitionPay.Models.Student
{
    public class Student
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int StudentId { get; set; }
        public string Gender { get; set; }
        public int YearOfBirth { get; set; }       
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
