﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System.API.Models.Domain
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly DOB { get; set; }
        public string Address { get; set; }
        public Guid SpecializationId { get; set; }

        //Navigation Property
        public Specialization Specialization { get; set; }
    }
}
