using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ticket_Reservation_system.Models.TrainModel
{
    public class Train
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("trainName")]
        public string TrainName { get; set; } = String.Empty;

        [BsonElement("departureStation")]
        public string DepartureStation { get; set; } = String.Empty;

        [BsonElement("arrivalStation")]
        public string ArrivalStation { get; set; } = String.Empty;

        [BsonElement("departureTime")]
        public string DepartureTime { get; set; } = String.Empty;

        [BsonElement("arrivalTime")]
        public string ArrivalTime { get; set; } = String.Empty;

        [BsonElement("distance")]
        public double Distance { get; set; }

        [BsonElement("duration")]
        public string Duration { get; set; } = String.Empty;

        [BsonElement("trainType")]
        public string TrainType { get; set; } = String.Empty;

        [BsonElement("availableSeats")]
        public int AvailableSeats { get; set; }

        [BsonElement("ticketPrice")]
        public decimal TicketPrice { get; set; }

        [BsonElement("departureDate")]
        public DateTime DepartureDate { get; set; }

        [BsonElement("trainStatus")]
        public bool TrainStatus { get; set; }
    }
}
