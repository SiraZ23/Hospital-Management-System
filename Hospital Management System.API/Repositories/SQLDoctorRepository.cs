using Hospital_Management_System.API.Data;
using Hospital_Management_System.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Doctor?> DeleteAsync(Guid id)
        {
            var existingDoctor=await dbContext.doctors.FirstOrDefaultAsync(x => x.Id == id);
            if (existingDoctor==null)
            {
                return null;
            }
            dbContext.doctors.Remove(existingDoctor);
            await dbContext.SaveChangesAsync();
            return existingDoctor;
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
            return await dbContext.doctors.ToListAsync();
        }

        public async Task<Doctor?> GetByIdAsync(Guid id)
        {
            return await dbContext.doctors.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Doctor?> UpdateAsync(Guid id, Doctor doctor)
        {
            var existingDoctor=await dbContext.doctors.FirstOrDefaultAsync(x=>x.Id == id);
            if(existingDoctor == null)
            {
                return null;
            }
            existingDoctor.Name=doctor.Name;
            existingDoctor.Address=doctor.Address;
            existingDoctor.PhoneNumber=doctor.PhoneNumber;
            existingDoctor.SpecializationId=doctor.SpecializationId;
            existingDoctor.DOB=doctor.DOB;
            await dbContext.SaveChangesAsync();
            return existingDoctor;
        }
    }
}
