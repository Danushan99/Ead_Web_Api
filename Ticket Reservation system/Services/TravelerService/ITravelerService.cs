using System;
using Ticket_Reservation_system.Models.Traveler;

namespace Ticket_Reservation_system.Services.TravelerService;

public interface ITravelerService
{
    List<Traveler> Get();
    Traveler Get(string id);
    Traveler Create(Traveler train);
    void Update(string id, Traveler train);
    void Remove(string id);
}