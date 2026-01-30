using BookingsAPI.Domain;
using BookingsAPI.Enums;
using BookingsAPI.Infrustructure;

namespace BookingsAPI.Application
{
    public class BookingService
    {
        private readonly IBookingRepository _repository;

        public BookingService(IBookingRepository repository)
        {
            _repository = repository;
        }

        public async Task<Booking> CreateAsync(
            string customerName,
            BookingType bookingType,
            DateTime start,
            DateTime end)
        {
            var booking = new Booking(customerName, bookingType, start, end);
            await _repository.AddAsync(booking);
            return booking;
        }

        public async Task UpdateAsync(Guid id, DateTime start, DateTime end)
        {
             var booking = await _repository.GetAsync(id)
                ?? throw new KeyNotFoundException("Booking not found");

            booking.UpdateDates(start, end);

            await _repository.UpdateAsync(id);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.RemoveAsync(id);
        }
    }
}
