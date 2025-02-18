namespace Hospital_Management_System.API.Models.DTO
{
    public class AddPatientDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Guid DoctorId { get; set; }
        public string Address { get; set; }
        public DateOnly DOB { get; set; }
    }
}
