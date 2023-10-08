using System;
namespace Ticket_Reservation_system.Models.UserModel
{
    public class UserStoreDatabaseSettings : IUserStoreDatabaseSettings
    {
        public string UserCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}