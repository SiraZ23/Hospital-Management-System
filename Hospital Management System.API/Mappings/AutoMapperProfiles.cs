using AutoMapper;
using Hospital_Management_System.API.Models.Domain;
using Hospital_Management_System.API.Models.DTO;

namespace Hospital_Management_System.API.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Patient,AddPatientDto>().ReverseMap();
            CreateMap<Patient,UpdatePatientDto>().ReverseMap();
            CreateMap<Patient,PatientDto>().ReverseMap();
            CreateMap<Doctor,AddDoctorDto>().ReverseMap();
            CreateMap<Doctor,UpdateDoctorDto>().ReverseMap();   
            CreateMap<Doctor,DoctorDto>().ReverseMap(); 
        }
    }
}
