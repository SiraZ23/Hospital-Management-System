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

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var patientDomainModel = await patientRepository.GetAllAsync();
            return Ok(mapper.Map <List<PatientDto>>(patientDomainModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var patientDomainModel=await patientRepository.GetByIdAsync(id);
            if (patientDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<PatientDto>(patientDomainModel));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute]Guid id, UpdatePatientDto updatePatientDto)
        {
            var patientDomainModel=mapper.Map<Patient>(updatePatientDto);
            patientDomainModel=await patientRepository.UpdateAsync(id,patientDomainModel);
            if (patientDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<PatientDto>(patientDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var deletedPatientDomainModel=await patientRepository.DeleteAsync(id);
            if (deletedPatientDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<PatientDto>(deletedPatientDomainModel));
        }
    }
}
