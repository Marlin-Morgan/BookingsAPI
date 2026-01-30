using BookingsAPI.Application;
using static BookingsAPI.Contracts.BookingDtos;
using BookingsAPI.Infrustructure;
using Microsoft.AspNetCore.Mvc;


namespace BookingsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly BookingService _service;
        private readonly IBookingRepository _repository;

        public BookingsController(
            BookingService service,
            IBookingRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bookings = await _repository.GetAllAsync();
            return Ok(bookings);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookingDto dto)
        {
            var booking = await _service.CreateAsync(
                dto.CustomerName,
                dto.BookingType,
                dto.StartDate,
                dto.EndDate);

            return CreatedAtAction(nameof(GetAll), new { id = booking.Id }, booking);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateBookingDto dto)
        {
            await _service.UpdateAsync(id, dto.StartDate, dto.EndDate);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
