namespace StudentsTuitionPay.Models.Student
{
    public class Course
    {
        public int Id { get; set; }        
        public int FacultyId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
