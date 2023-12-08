using System.Collections.Generic;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;

namespace Vezeeta.Core.Interfaces.Repositories
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetAllBookingsAsync(int page, int pageSize, string search);
        Task<Booking> GetBookingByIdAsync(int id);
        Task<int> AddBookingAsync(Booking booking);
        Task<bool> UpdateBookingAsync(Booking booking);
        Task<bool> DeleteBookingAsync(int id);

    }
}
