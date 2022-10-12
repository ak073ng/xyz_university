namespace StudentsTuitionPay.Models.Student.Interfaces
{
    public interface IFacultyRepository
    {
        Task<IEnumerable<Faculty>> Faculties();
        Task<Faculty> getFacultyById(int id);
        Task<Faculty> AddFaculty(Faculty faculty);
        Task<Faculty> UpdateFaculty(Faculty faculty);
        Task DeleteFaculty(int id);
    }
}
