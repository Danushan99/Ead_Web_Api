using System;
using Ticket_Reservation_system.Models.userModel;


namespace Ticket_Reservation_system.Services.UserService
{
    public interface IUserService
    {
        User Register(User user);
        User Authenticate(string? username, string? password);
    }
}