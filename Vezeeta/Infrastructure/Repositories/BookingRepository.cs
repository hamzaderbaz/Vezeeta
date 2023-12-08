using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;
using Vezeeta.Core.Interfaces.Repositories;
using Vezeeta.Infrastructure.Context;

namespace Vezeeta.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync(int page, int pageSize, string search)
        {
            var bookingsQuery = _context.Bookings.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                bookingsQuery = bookingsQuery.Where(b => b.DoctorName.Contains(search));
            }

            return await bookingsQuery.Skip((page - 1) * pageSize)
                                     .Take(pageSize)
                                     .ToListAsync();
        }


    }
}
