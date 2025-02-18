using Hospital_Management_System.API.Data;
using Hospital_Management_System.API.Models.Domain;

namespace Hospital_Management_System.API.Repositories
{
    public class SQLPatientRepositorycs:IPatientRepository
    {
        private readonly HospitalManagementDbContext dbContext;

        public SQLPatientRepositorycs(HospitalManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Patient> CreateAsync(Patient patient)
        {
            await dbContext.patients.AddAsync(patient);
            await dbContext.SaveChangesAsync();
            return patient;
        }

        public Task<Patient?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Patient>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Patient?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Patient?> UpdateAsync(Guid id, Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
