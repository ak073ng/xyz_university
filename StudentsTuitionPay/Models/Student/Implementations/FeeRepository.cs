using Microsoft.EntityFrameworkCore;
using StudentsTuitionPay.Models.Student.Interfaces;
using StudentsTuitionPay.Models.Student.Utility;

namespace StudentsTuitionPay.Models.Student.Implementations
{
    public class FeeRepository : IFeeRepository
    {
        private readonly StudentDbContext DbContext;

        public FeeRepository(StudentDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IEnumerable<Fee>> Fees()
        {
            var List = await DbContext.Fees.Select(
                f => new Fee
                {
                    Id = f.Id,
                    Year = f.Year,
                    Semester = f.Semester,
                    Amount = f.Amount,
                    CourseId = f.CourseId,
                    CreatedAt = f.CreatedAt,
                    UpdatedAt = f.UpdatedAt
                }
            ).ToListAsync();

            return List;
        }

        public async Task<Fee> getFeeById(int id)
        {
            Fee Fee = await DbContext.Fees.Select(
                f => new Fee
                {
                    Id = f.Id,
                    Year = f.Year,
                    Semester = f.Semester,
                    Amount = f.Amount,
                    CourseId = f.CourseId,
                    CreatedAt = f.CreatedAt,
                    UpdatedAt = f.UpdatedAt
                }
            ).FirstOrDefaultAsync(f => f.Id == id);

            return Fee;
        }

        public async Task<Fee> AddFee(Fee fee)
        {
            var Fee = new Fee()
            {
                Year = fee.Year,
                Semester = fee.Semester,
                Amount = fee.Amount,
                CourseId = fee.CourseId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            DbContext.Fees.Add(Fee);

            await DbContext.SaveChangesAsync();

            return Fee;
        }

        public async Task<Fee> UpdateFee(Fee fee)
        {
            var Fee = await DbContext.Fees.FirstOrDefaultAsync(f => f.Id == fee.Id);

            if (Fee != null)
            {
                Fee.Year = fee.Year;
                Fee.Semester = fee.Semester;
                Fee.Amount = fee.Amount;
                Fee.CourseId = fee.CourseId;
                Fee.UpdatedAt = DateTime.Now;

                await DbContext.SaveChangesAsync();
            }

            return Fee;
        }

        public async Task DeleteFee(int id)
        {
            var Fee = new Fee() { Id = id };

            DbContext.Fees.Attach(Fee);

            DbContext.Fees.Remove(Fee);

            await DbContext.SaveChangesAsync();
        }
    }
}
