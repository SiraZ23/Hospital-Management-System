using Hospital_Management_System.API.Models.Domain;

namespace Hospital_Management_System.API.Repositories
{
    public interface IPatientRepository
    {
        Task<Patient> CreateAsync(Patient patient);
        Task<List<Patient>> GetAllAsync();
        Task<Patient?> GetByIdAsync(Guid id);
        Task<Patient?> UpdateAsync(Guid id,Patient patient);
        Task<Patient?> DeleteAsync(Guid id);
    }
}
