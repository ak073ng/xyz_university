using Microsoft.EntityFrameworkCore;
using StudentsTuitionPay.Models.Student.Interfaces;
using StudentsTuitionPay.Models.Student.Utility;

namespace StudentsTuitionPay.Models.Student.Implementations
{
    public class CourseRepository : ICourseRepository
    {
        private readonly StudentDbContext DbContext;

        public CourseRepository(StudentDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IEnumerable<Course>> Courses()
        {
            var List = await DbContext.Courses.Select(
                c => new Course
                {
                    Id = c.Id,
                    Name = c.Name,
                    FacultyId = c.FacultyId,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                }
            ).ToListAsync();

            return List;
        }

        public async Task<Course> getCourseById(int id)
        {
            Course Course = await DbContext.Courses.Select(
                c => new Course
                {
                    Id = c.Id,
                    Name = c.Name,
                    FacultyId = c.FacultyId,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                }
            ).FirstOrDefaultAsync(c => c.Id == id);

            return Course;
        }

        public async Task<Course> AddCourse(Course course)
        {
            var Course = new Course()
            {
                Name = course.Name,
                FacultyId = course.FacultyId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            DbContext.Courses.Add(Course);

            await DbContext.SaveChangesAsync();

            return Course;
        }

        public async Task<Course> UpdateCourse(Course course)
        {
            var Course = await DbContext.Courses.FirstOrDefaultAsync(c => c.Id == course.Id);

            if (Course != null)
            {
                Course.Name = course.Name;
                Course.FacultyId = course.FacultyId;
                Course.UpdatedAt = DateTime.Now;

                await DbContext.SaveChangesAsync();
            }

            return Course;
        }

        public async Task DeleteCourse(int id)
        {
            var Course = new Course() { Id = id };

            DbContext.Courses.Attach(Course);

            DbContext.Courses.Remove(Course);

            await DbContext.SaveChangesAsync();
        }

    }
}
