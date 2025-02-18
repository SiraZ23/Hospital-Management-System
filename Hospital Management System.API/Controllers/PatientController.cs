using AutoMapper;
using Hospital_Management_System.API.Models.Domain;
using Hospital_Management_System.API.Models.DTO;
using Hospital_Management_System.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository patientRepository;
        private readonly IMapper mapper;

        public PatientController(IPatientRepository patientRepository,IMapper mapper)
        {
            this.patientRepository = patientRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult>CreateAsync([FromBody] AddPatientDto addPatient)
        {
            //Map DTO Domain Model 
            var patientDomainModel=mapper.Map<Patient>(addPatient);

            //Making Repository For Walks
            await patientRepository.CreateAsync(patientDomainModel);    

            //Map Domain Model To DTO
            return Ok(mapper.Map<Patient>(patientDomainModel));
        }
    }
}
