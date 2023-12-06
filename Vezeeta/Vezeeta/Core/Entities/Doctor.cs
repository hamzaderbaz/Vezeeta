using System;
using System.Collections.Generic;

namespace Vezeeta.Core.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Specialize { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        // Additional properties might be added based on application requirements
        
        public ICollection<Booking> Bookings { get; set; }
    }

    public enum Gender
    {
        Female = 0,
        Male = 1
    }

}
