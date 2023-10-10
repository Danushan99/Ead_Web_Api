using System;
using MongoDB.Driver;
using Ticket_Reservation_system.Models.bookingModel;

namespace Ticket_Reservation_system.Services.BookingService
{
  

        public class BookingService : IBookingService
        {
            private readonly IMongoCollection<Booking> _booking;

            public BookingService(IBookingStoreDatabaseSettings settings, IMongoClient mongoClient)
            {
                var database = mongoClient.GetDatabase(settings.DatabaseName);
                _booking = database.GetCollection<Booking>(settings.BookingCollectionName);
            }

            public Booking Create(Booking booking)
            {
                _booking.InsertOne(booking);
                return booking;
            }

            public List<Booking> Get()
            {
                return _booking.Find(booking => true).ToList();
            }

            public Booking Get(string id)
            {
                return _booking.Find(booking => booking.Id == id).FirstOrDefault();
            }

            public void Remove(string id) => _booking.DeleteOne(booking => booking.Id == id);

            public void Update(string id, Booking booking)
            {
                _booking.ReplaceOne(booking => booking.Id == id, booking);
            }
        }
    }
