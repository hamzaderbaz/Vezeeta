using System;
using System.Collections.Generic;

namespace Vezeeta.Core.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

 
        public ICollection<Booking> Bookings { get; set; }
    }

    public enum Gender
    {
        Female = 0,
        Male = 1
    }

}
