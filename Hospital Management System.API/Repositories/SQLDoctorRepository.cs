using Hospital_Management_System.API.Data;
using Hospital_Management_System.API.Models.Domain;

namespace Hospital_Management_System.API.Repositories
{
    public class SQLDoctorRepository:IDoctorRepository
    {
        private readonly HospitalManagementDbContext dbContext;

        public SQLDoctorRepository(HospitalManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Doctor> CreateAsync(Doctor doctor)
        {
            await dbContext.doctors.AddAsync(doctor);
            await dbContext.SaveChangesAsync();
            return doctor;
        }

        public Task<Doctor?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Doctor>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Doctor?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Doctor?> UpdateAsync(Guid id, Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}
