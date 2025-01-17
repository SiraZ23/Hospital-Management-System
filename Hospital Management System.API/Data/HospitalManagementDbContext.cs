using Hospital_Management_System.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.API.Data
{
    public class HospitalManagementDbContext:DbContext
    {
        public HospitalManagementDbContext(DbContextOptions  dbContextOptions):base(dbContextOptions) 
        {
            
        }

        public DbSet<Patient> patients { get; set; }
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<Specialization> specializations { get; set; }
    }
}
