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
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository doctorRepository;
        private readonly IMapper mapper;

        public DoctorController(IDoctorRepository doctorRepository,IMapper mapper)
        {
            this.doctorRepository = doctorRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AddDoctorDto addDoctorDto)
        {
            //Map Domain Model To DTO
            var doctorDomainModel = mapper.Map<Doctor>(addDoctorDto);

            //Making Repository For Doctors
            await doctorRepository.CreateAsync(doctorDomainModel);

            //Map DTO To Domain Model
            return Ok(mapper.Map<DoctorDto>(doctorDomainModel));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var doctorDomainModel=await doctorRepository.GetAllAsync();
            return Ok(mapper.Map<List<DoctorDto>>(doctorDomainModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute]Guid id)
        {
            var doctorDomainModel=await doctorRepository.GetByIdAsync(id);
            if (doctorDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<DoctorDto>(doctorDomainModel));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute]Guid id ,UpdateDoctorDto updateDoctorDto)
        {
            var doctorDomainModel=mapper.Map<Doctor>(updateDoctorDto);
            doctorDomainModel = await doctorRepository.UpdateAsync(id, doctorDomainModel);
            if (doctorDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<DoctorDto>(doctorDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]Guid id)
        {
            var deletedDoctorDomainModel=await doctorRepository.DeleteAsync(id);
            if (deletedDoctorDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<DoctorDto>(deletedDoctorDomainModel));
        }
    }
}
