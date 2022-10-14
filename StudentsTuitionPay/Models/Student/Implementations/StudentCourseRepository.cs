using Microsoft.EntityFrameworkCore;
using StudentsTuitionPay.Models.Student.Utility;
using StudentsTuitionPay.Models.Student.Interfaces;

namespace StudentsTuitionPay.Models.Student.Implementations
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly StudentDbContext DbContext;

        public StudentCourseRepository(StudentDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IEnumerable<StudentCourse>> StudentCourses()
        {
            var List = await DbContext.StudentCourses.Select(
                s => new StudentCourse
                {
                    Id = s.Id,
                    StudentId = s.StudentId,
                    CourseId = s.CourseId,
                    DateStarted = s.DateStarted,
                    CreatedAt = s.CreatedAt,
                    UpdatedAt = s.UpdatedAt
                }
            ).ToListAsync();

            return List;
        }

        public async Task<StudentCourse> getStudentCourseById(int id)
        {
            StudentCourse StudentCourse = await DbContext.StudentCourses.Select(
                s => new StudentCourse
                {
                    Id = s.Id,
                    StudentId = s.StudentId,
                    CourseId = s.CourseId,
                    DateStarted = s.DateStarted,
                    CreatedAt = s.CreatedAt,
                    UpdatedAt = s.UpdatedAt
                }
            ).FirstOrDefaultAsync(s => s.Id == id);

            return StudentCourse;
        }

        public async Task<StudentCourse> AddStudentCourse(StudentCourse studentCourse)
        {
            var StudentCourse = new StudentCourse()
            {
                StudentId = studentCourse.StudentId,
                CourseId = studentCourse.CourseId,
                DateStarted = studentCourse.DateStarted,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            DbContext.StudentCourses.Add(StudentCourse);

            await DbContext.SaveChangesAsync();

            return StudentCourse;
        }

        public async Task<StudentCourse> UpdateStudentCourse(StudentCourse studentCourse)
        {
            var StudentCourse = await DbContext.StudentCourses.FirstOrDefaultAsync(s => s.Id == studentCourse.Id);

            if (StudentCourse != null)
            {
                StudentCourse.StudentId = studentCourse.StudentId;
                StudentCourse.CourseId = studentCourse.CourseId;
                StudentCourse.DateStarted = studentCourse.DateStarted;
                StudentCourse.UpdatedAt = DateTime.Now;

                await DbContext.SaveChangesAsync();
            }

            return StudentCourse;
        }

        public async Task DeleteStudentCourse(int id)
        {
            var StudentCourse = new StudentCourse() { Id = id };

            DbContext.StudentCourses.Attach(StudentCourse);

            DbContext.StudentCourses.Remove(StudentCourse);

            await DbContext.SaveChangesAsync();
        }
    }
}
