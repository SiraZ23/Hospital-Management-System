namespace Hospital_Management_System.API.Models.DTO
{
    public class UpdateDoctorDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly DOB { get; set; }
        public string Address { get; set; }
        public Guid Specialization_Id { get; set; }
    }
}
