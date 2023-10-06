using Ticket_Reservation_system.Models.TrainModel;

namespace Ticket_Reservation_system.Models
{
    public class TrainStoreDatabaseSettings : ITrainStoreDatabaseSettings
    {
        public string TrainCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
