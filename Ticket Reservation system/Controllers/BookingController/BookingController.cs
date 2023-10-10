using System;
using Microsoft.AspNetCore.Mvc;
using Ticket_Reservation_system.Models.bookingModel;
using Ticket_Reservation_system.Services.BookingService;

namespace Ticket_Reservation_system.Controllers.BookingController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        // GET: api/<BookingController>
        [HttpGet]
        public ActionResult<List<Booking>> Get() => bookingService.Get();

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public ActionResult<Booking> Get(string id)
        {
            var booking = bookingService.Get(id);

            if (booking == null)
            {
                return NotFound($"booking with id = {id} not found");
            };

            return booking;
        }

        // POST api/<BookingController>
        [HttpPost]
        public ActionResult<Booking> Post([FromBody] Booking booking)
        {
            bookingService.Create(booking);

            return CreatedAtAction(nameof(Get), new { id = booking.Id }, booking);
        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Booking booking)
        {
            var excistingBooking = bookingService.Get(id);

            if (excistingBooking == null)
            {
                return NotFound($"Booking with id = {id} not found");
            };

            bookingService.Update(id, booking);

            return NoContent();
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var booking = bookingService.Get(id);

            if (booking == null)
            {
                return NotFound($"booking with id = {id} not found");
            };

            bookingService.Remove(booking.Id);

            return Ok($"booking with Id = {id} deleted");
        }
    }
}
