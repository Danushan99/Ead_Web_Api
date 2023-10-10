using System;
using Ticket_Reservation_system.Models.bookingModel;


namespace Ticket_Reservation_system.Services.BookingService
{
    public interface IBookingService
    {
        List<Booking> Get();
        Booking Get(string id);
        Booking Create(Booking booking);
        void Update(string id, Booking booking);
        void Remove(string id);
    }
}
