using System;
namespace Ticket_Reservation_system.Models.TravelerModule;


public class TravelerStoreDatabaseSettings : ITravelerStoreDatabaseSettings
{
    public string TravelerCollectionName { get; set; } = String.Empty;
    public string ConnectionString { get; set; } = String.Empty;
    public string DatabaseName { get; set; } = String.Empty;
}

