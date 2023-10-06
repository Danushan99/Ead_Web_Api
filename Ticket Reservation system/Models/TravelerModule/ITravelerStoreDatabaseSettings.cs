using System;
namespace Ticket_Reservation_system.Models.TravelerModule
{
	public interface ITravelerStoreDatabaseSettings
	{
        string TravelerCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}

