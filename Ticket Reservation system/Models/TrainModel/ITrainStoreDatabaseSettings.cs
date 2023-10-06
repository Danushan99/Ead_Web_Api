using System;
namespace Ticket_Reservation_system.Models.TrainModel
{
	public interface ITrainStoreDatabaseSettings
	{
        string TrainCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}

