using BookingsAPI.Enums;

namespace BookingsAPI.Contracts
{
    public class BookingDtos
    {
        public record CreateBookingDto(
            string CustomerName,
            BookingType BookingType,
            DateTime StartDate,
            DateTime EndDate
        );

        public record UpdateBookingDto(
            DateTime StartDate,
            DateTime EndDate
        );
    }
}
