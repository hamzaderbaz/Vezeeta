using Microsoft.EntityFrameworkCore;
using Vezeeta.Core.Entities;

namespace Vezeeta.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<DiscountCode> DiscountCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            
            base.OnModelCreating(modelBuilder);
        }
    }
}
