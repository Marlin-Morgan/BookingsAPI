using BookingsAPI.Enums;

namespace BookingsAPI.Domain
{
    public class Booking
    {
        public Guid Id { get; private set; }
        public string CustomerName { get; private set; } = null!;
        public BookingType BookingType { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        private Booking() { } // EF Core

        public Booking(string customerName, BookingType bookingType, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(customerName))
                throw new ArgumentException("Customer name is required");

            if (endDate <= startDate)
                throw new ArgumentException("End date must be after start date");

            Id = Guid.NewGuid();
            CustomerName = customerName;
            BookingType = bookingType;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void UpdateDates(DateTime startDate, DateTime endDate)
        {
            if (endDate <= startDate)
                throw new ArgumentException("Invalid date range");

            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
