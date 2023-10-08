using System;
namespace Ticket_Reservation_system.Models.UserModel
{
    public class UserLoginRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}