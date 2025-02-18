using Hospital_Management_System.API.Models.Domain;

namespace Hospital_Management_System.API.Repositories
{
    public interface IDoctorRepository
    {
        Task<Doctor> CreateAsync(Doctor doctor);
        Task<List<Doctor>> GetAllAsync();
        Task<Doctor?> GetByIdAsync(Guid id);
        Task<Doctor?> UpdateAsync(Guid id, Doctor doctor);
        Task <Doctor?>DeleteAsync(Guid id);
    }
}
