
using MongoDB.Driver;
using Ticket_Reservation_system.Models.Traveler;
using Ticket_Reservation_system.Models.TravelerModule;


namespace Ticket_Reservation_system.Services.TravelerService;

public class TravelerService : ITravelerService
{
    private readonly IMongoCollection<Traveler> _traveler;

    public TravelerService(ITravelerStoreDatabaseSettings settings, IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase(settings.DatabaseName);
        _traveler = database.GetCollection<Traveler>(settings.TravelerCollectionName);
    }

    public Traveler Create(Traveler traveler)
    {
        _traveler.InsertOne(traveler);
        return traveler;
    }

    public List<Traveler> Get()
    {
        return _traveler.Find(traveler => true).ToList();
    }

    public Traveler Get(string id)
    {
        return _traveler.Find(traveler => traveler.Id == id).FirstOrDefault();
    }

    public void Remove(string id) => _traveler.DeleteOne(traveler => traveler.Id == id);

    public void Update(string id, Traveler traveler)
    {
        _traveler.ReplaceOne(traveler => traveler.Id == id, traveler);
    }
}

