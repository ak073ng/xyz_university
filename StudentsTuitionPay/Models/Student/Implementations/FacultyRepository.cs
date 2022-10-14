using Microsoft.EntityFrameworkCore;
using StudentsTuitionPay.Models.Student.Interfaces;
using StudentsTuitionPay.Models.Student.Utility;

namespace StudentsTuitionPay.Models.Student.Implementations
{
    public class FacultyRepository : IFacultyRepository
    {
        private readonly StudentDbContext DbContext;

        public FacultyRepository(StudentDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IEnumerable<Faculty>> Faculties()
        {
            var List = await DbContext.Faculties.Select(
                f => new Faculty
                {
                    Id = f.Id,
                    Name = f.Name,
                    CreatedAt = f.CreatedAt,
                    UpdatedAt = f.UpdatedAt
                }
            ).ToListAsync();

            return List;
        }

        public async Task<Faculty> getFacultyById(int id)
        {
            Faculty Faculty = await DbContext.Faculties.Select(
                f => new Faculty
                {
                    Id = f.Id,
                    Name = f.Name,
                    CreatedAt = f.CreatedAt,
                    UpdatedAt = f.UpdatedAt
                }
            ).FirstOrDefaultAsync(f => f.Id == id);

            return Faculty;
        }

        public async Task<Faculty> AddFaculty(Faculty faculty)
        {
            var Faculty = new Faculty()
            {
                Name = faculty.Name,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            DbContext.Faculties.Add(Faculty);

            await DbContext.SaveChangesAsync();

            return Faculty;
        }

        public async Task<Faculty> UpdateFaculty(Faculty faculty)
        {
            var Faculty = await DbContext.Faculties.FirstOrDefaultAsync(f => f.Id == faculty.Id);

            if (Faculty != null)
            {
                Faculty.Name = faculty.Name;
                Faculty.UpdatedAt = DateTime.Now;

                await DbContext.SaveChangesAsync();
            }

            return Faculty;
        }

        public async Task DeleteFaculty(int id)
        {
            var Faculty = new Faculty() { Id = id };

            DbContext.Faculties.Attach(Faculty);

            DbContext.Faculties.Remove(Faculty);

            await DbContext.SaveChangesAsync();
        }
    }
}
