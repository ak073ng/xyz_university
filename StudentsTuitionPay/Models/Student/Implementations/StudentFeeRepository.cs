using Microsoft.EntityFrameworkCore;
using StudentsTuitionPay.Models.Student.Interfaces;
using StudentsTuitionPay.Models.Student.Utility;

namespace StudentsTuitionPay.Models.Student.Implementations
{
    public class StudentFeeRepository : IStudentFeeRepository
    {
        private readonly StudentDbContext DbContext;

        public StudentFeeRepository(StudentDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IEnumerable<StudentFee>> StudentFees()
        {
            var List = await DbContext.StudentFees.Select(
                s => new StudentFee
                {
                    Id = s.Id,
                    StudentId = s.StudentId,
                    FeeId = s.FeeId,
                    AmountPaid = s.AmountPaid,
                    CreatedAt = s.CreatedAt,
                    UpdatedAt = s.UpdatedAt
                }
            ).ToListAsync();

            return List;
        }

        public async Task<StudentFee> getStudenFeeById(int id)
        {
            StudentFee StudentFee = await DbContext.StudentFees.Select(
                s => new StudentFee
                {
                    Id = s.Id,
                    StudentId = s.StudentId,
                    FeeId = s.FeeId,
                    AmountPaid = s.AmountPaid,
                    CreatedAt = s.CreatedAt,
                    UpdatedAt = s.UpdatedAt
                }
            ).FirstOrDefaultAsync(s => s.Id == id);

            return StudentFee;
        }

        public async Task<StudentFee> AddStudentFee(StudentFee studentFee)
        {
            var StudentFee = new StudentFee()
            {
                StudentId = studentFee.StudentId,
                FeeId = studentFee.FeeId,
                AmountPaid = studentFee.AmountPaid,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            DbContext.StudentFees.Add(StudentFee);

            await DbContext.SaveChangesAsync();

            return StudentFee;
        }

        public async Task<StudentFee> UpdateStudentFee(StudentFee studentFee)
        {
            var StudentFee = await DbContext.StudentFees.FirstOrDefaultAsync(s => s.Id == studentFee.Id);

            if (StudentFee != null)
            {
                StudentFee.StudentId = studentFee.StudentId;
                StudentFee.FeeId = studentFee.FeeId;
                StudentFee.AmountPaid = studentFee.AmountPaid;
                StudentFee.UpdatedAt = DateTime.Now;

                await DbContext.SaveChangesAsync();
            }

            return StudentFee;
        }

        public async Task DeleteStudentFee(int id)
        {
            var StudentFee = new StudentFee() { Id = id };

            DbContext.StudentFees.Attach(StudentFee);

            DbContext.StudentFees.Remove(StudentFee);

            await DbContext.SaveChangesAsync();
        }
    }
}
