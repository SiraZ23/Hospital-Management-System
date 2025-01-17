namespace Hospital_Management_System.API.Models.Domain
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Guid Doctor_Id { get; set; }
        public string Address { get; set; }
        public DateOnly DOB { get; set; }

        //Navigation Property
        public Doctor Doctor { get; set; }
    }
}
