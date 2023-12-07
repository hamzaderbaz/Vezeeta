using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;
using Vezeeta.Core.Interfaces.Repositories;
using Vezeeta.Core.Interfaces.UseCases;

namespace Vezeeta.Application.UseCases
{
    public class BookingUseCase : IBookingUseCase
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingUseCase(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync(int page, int pageSize, string search)
        {
            return await _bookingRepository.GetAllBookingsAsync(page, pageSize, search);
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await _bookingRepository.GetBookingByIdAsync(id);
        }


    }
}
