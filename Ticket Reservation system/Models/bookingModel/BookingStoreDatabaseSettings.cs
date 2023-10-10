using System;
namespace Ticket_Reservation_system.Models.bookingModel
{
	public class BookingStoreDatabaseSettings : IBookingStoreDatabaseSettings
    {
        public string BookingCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}

