namespace StudentsTuitionPay.Models.Student.Interfaces
{
    public interface IStudentCourseRepository
    {
        Task<IEnumerable<StudentCourse>> StudentCourses();
        Task<StudentCourse> getStudentCourseById(int id);
        Task<StudentCourse> AddStudentCourse(StudentCourse studentCourse);
        Task<StudentCourse> UpdateStudentCourse(StudentCourse studentCourse);
        Task DeleteStudentCourse(int id);
    }
}
