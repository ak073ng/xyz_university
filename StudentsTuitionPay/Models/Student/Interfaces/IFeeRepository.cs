namespace StudentsTuitionPay.Models.Student.Interfaces
{
    public interface IFeeRepository
    {
        Task<IEnumerable<Fee>> Fees();
        Task<Fee> getFeeById(int id);
        Task<Fee> AddFee(Fee fee);
        Task<Fee> UpdateFee(Fee fee);
        Task DeleteFee(int id);
    }
}
