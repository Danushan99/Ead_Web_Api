using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ticket_Reservation_system.Models.bookingModel;

public class Booking
{
    

   
    
     [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("travalerNIC")]
        public string TravalerNIC { get; set; } = String.Empty;

        [BsonElement("dateofbooking")]
        public DateTime DateofBooking { get; set; }

        [BsonElement("dateofreseravtion")]
        public DateTime DateofReseravtion { get; set; }

        [BsonElement("refid")]
        public string RefID { get; set; } = String.Empty;

    
}
