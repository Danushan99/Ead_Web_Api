using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ticket_Reservation_system.Models.Traveler
{
    public class Traveler
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("travelerName")]
        public string TravelerName { get; set; } = String.Empty;

        [BsonElement("nic")]
        public string Nic { get; set; } = String.Empty;

        [BsonElement("phone")]
        public string Phone { get; set; } = String.Empty;

        [BsonElement("address")]
        public string Address { get; set; } = String.Empty;

        [BsonElement("status")]
        public bool Status { get; set; } 

        [BsonElement("password")]
        public string Password { get; set; } = String.Empty;

    }
}
