namespace StudentsTuitionPay.Models.Student.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> Courses();
        Task<Course> getCourseById(int id);
        Task<Course> AddCourse(Course course);
        Task<Course> UpdateCourse(Course course);
        Task DeleteCourse(int id);
    }
}
