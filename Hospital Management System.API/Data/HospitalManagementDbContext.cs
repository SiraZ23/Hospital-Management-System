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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Data For Specializations
            var specializations = new List<Specialization>()
            {
                 new Specialization()
                   {
                    Id=Guid.Parse("2d5ad721-36b1-42f1-9021-c7280238441b"),
                    Name="Cardiologist"
                   },
                 new Specialization()
                  {
                    Id=Guid.Parse("334b78bb-2e06-4bee-9900-cb5e28e179b1"),
                    Name="Gynecologist"
                  },
                 new Specialization()
                  {
                    Id=Guid.Parse("813d8f77-7f44-4724-8339-27c4cff71722"),
                    Name="Otolaryngologist"
                  },
                 new Specialization()
                  {
                    Id=Guid.Parse("d13e5c90-e097-4967-92f5-640f426494ba"),
                    Name="Neurologist"
                  },
                 new Specialization()
                  {
                    Id=Guid.Parse("ff701083-3361-4e21-9b7b-c187c0f790f1"),
                    Name="Orthopedist"
                  },
                 new Specialization()
                 {
                     Id=Guid.Parse("a4104ba2-f53d-43d9-b62d-41ed1830e468"),
                     Name="General Physician"
                 }
            };
            //Seed Specialization To The DB
            modelBuilder.Entity<Specialization>().HasData(specializations);
        }
    }
}
