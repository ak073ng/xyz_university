using Microsoft.EntityFrameworkCore;
using StudentsTuitionPay.Models.Student.Utility;
using StudentsTuitionPay.Models.Student.Interfaces;

namespace StudentsTuitionPay.Models.Student.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext DbContext;

        public StudentRepository(StudentDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IEnumerable<Student>> Students()
        {
            var List = await DbContext.Students.Select(
                s => new Student
                {
                    Id = s.Id,
                    Name = s.Name,
                    StudentId = s.StudentId,
                    Gender = s.Gender,
                    YearOfBirth = s.YearOfBirth,
                    PhoneNumber = s.PhoneNumber,
                    Email = s.Email,
                    CreatedAt = s.CreatedAt,
                    UpdatedAt = s.UpdatedAt
                }
            ).ToListAsync();

            return List;
        }

        public async Task<Student> getStudentById(int id)
        {
            Student Student = await DbContext.Students.Select(
                s => new Student
                {
                    Id = s.Id,
                    Name = s.Name,
                    StudentId = s.StudentId,
                    Gender = s.Gender,
                    YearOfBirth = s.YearOfBirth,
                    PhoneNumber = s.PhoneNumber,
                    Email = s.Email,
                    CreatedAt = s.CreatedAt,
                    UpdatedAt = s.UpdatedAt
                }
            ).FirstOrDefaultAsync(s => s.Id == id);

            return Student;
        }

        public async Task<Student> AddStudent(Student student)
        {
            var Student = new Student()
            {
                Name = student.Name,
                StudentId = student.StudentId,
                Gender = student.Gender,
                YearOfBirth = student.YearOfBirth,
                PhoneNumber = student.PhoneNumber,
                Email = student.Email,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            DbContext.Students.Add(Student);

            await DbContext.SaveChangesAsync();

            return Student;
        }        

        public async Task<Student> UpdateStudent(Student student)
        {
            var Student = await DbContext.Students.FirstOrDefaultAsync(s => s.Id == student.Id);

            if (Student != null)
            {
                Student.Name = student.Name;
                Student.StudentId = student.StudentId;
                Student.Gender = student.Gender;
                Student.YearOfBirth = student.YearOfBirth;
                Student.PhoneNumber = student.PhoneNumber;
                Student.Email = student.Email;
                Student.UpdatedAt = DateTime.Now;

                await DbContext.SaveChangesAsync();
            }

            return Student;
        }

        public async Task DeleteStudent(int id)
        {
            var Student = new Student() { Id = id };

            DbContext.Students.Attach(Student);

            DbContext.Students.Remove(Student);

            await DbContext.SaveChangesAsync();
        }
    }
}
