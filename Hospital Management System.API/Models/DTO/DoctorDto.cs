namespace Hospital_Management_System.API.Models.DTO
{
    public class DoctorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly DOB { get; set; }
        public string Address { get; set; }
        public Guid SpecializationId { get; set; }
    }
}
