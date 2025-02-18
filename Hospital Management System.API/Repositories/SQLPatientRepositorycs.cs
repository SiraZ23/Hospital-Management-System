using Hospital_Management_System.API.Data;
using Hospital_Management_System.API.Models.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Patient?> DeleteAsync(Guid id)
        {
            var existingPatient=await dbContext.patients.FirstOrDefaultAsync(x=>x.Id==id);
            if (existingPatient==null)
            {
                return null;
            }
            dbContext.patients.Remove(existingPatient);
            await dbContext.SaveChangesAsync();
            return existingPatient;
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            return await dbContext.patients.ToListAsync();
        }

        public async Task<Patient?> GetByIdAsync(Guid id)
        {
            return await dbContext.patients.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<Patient?> UpdateAsync(Guid id, Patient patient)
        {
            var existingPatient=await dbContext.patients.FirstOrDefaultAsync(x=>x.Id==id);
            if (existingPatient==null)
            {
                return null;
            }
            existingPatient.Name = patient.Name;
            existingPatient.PhoneNumber = patient.PhoneNumber;
            existingPatient.DoctorId = patient.DoctorId;
            existingPatient.Address = patient.Address;
            existingPatient.DOB = patient.DOB;
            await dbContext.SaveChangesAsync();
            return existingPatient;
        }
    }
}
