using System;
namespace Ticket_Reservation_system.Models.bookingModel
{
    public interface IBookingStoreDatabaseSettings
    {
        string BookingCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}


