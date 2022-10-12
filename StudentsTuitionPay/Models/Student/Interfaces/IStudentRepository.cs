namespace StudentsTuitionPay.Models.Student.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> Students();
        Task<Student> getStudentById(int id);
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task DeleteStudent(int id);
    }
}
