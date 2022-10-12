namespace StudentsTuitionPay.Models.Student.Interfaces
{
    public interface IStudentFeeRepository
    {
        Task<IEnumerable<StudentFee>> StudentFees();
        Task<StudentFee> getStudenFeeById(int id);
        Task<StudentFee> AddStudentFee(StudentFee studentFee);
        Task<StudentFee> UpdateStudentFee(StudentFee studentFee);
        Task DeleteStudentFee(int id);
    }
}
