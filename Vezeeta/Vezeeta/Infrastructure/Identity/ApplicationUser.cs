using Microsoft.AspNetCore.Identity;

namespace Vezeeta.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public int Id { get; set; }
        public string Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        
        public ICollection<Booking> Bookings { get; set; }


    }
}
