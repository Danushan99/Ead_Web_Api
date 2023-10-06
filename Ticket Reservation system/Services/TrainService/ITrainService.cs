using System;
using Ticket_Reservation_system.Models.TrainModel;

namespace Ticket_Reservation_system.Services.TrainService
{
	public interface ITrainService
	{
		List<Train> Get();
		Train Get(string id);
		Train Create(Train train);
		void Update(string id, Train train);
		void Remove(string id);
	}
}

