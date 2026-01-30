using BookingsAPI.Domain;

namespace BookingsAPI.Infrustructure
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<Booking?> GetAsync(Guid id);
        Task AddAsync(Booking booking);
        Task UpdateAsync(Guid id);
        Task RemoveAsync(Guid id);
    }
}
