using System;
using MongoDB.Driver;
using Ticket_Reservation_system.Models;
using Ticket_Reservation_system.Models.TrainModel;

namespace Ticket_Reservation_system.Services.TrainService
{
    public class TrainService : ITrainService
    {
        private readonly IMongoCollection<Train> _train;

        public TrainService(ITrainStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _train = database.GetCollection<Train>(settings.TrainCollectionName);
        }

        public Train Create(Train train)
        {
            _train.InsertOne(train);
            return train;
        }

        public List<Train> Get()
        {
            return _train.Find(train => true).ToList();
        }

        public Train Get(string id)
        {
            return _train.Find(train => train.Id == id).FirstOrDefault();
        }

        public void Remove(string id) => _train.DeleteOne(train => train.Id == id);

        public void Update(string id, Train train)
        {
            _train.ReplaceOne(train => train.Id == id, train);
        }
    }
}

