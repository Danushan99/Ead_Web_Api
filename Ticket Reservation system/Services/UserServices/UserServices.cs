using System;
using MongoDB.Driver;
using Ticket_Reservation_system.Models.userModel;
using Ticket_Reservation_system.Models.UserModel;


namespace Ticket_Reservation_system.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IUserStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<User>(settings.UserCollectionName);
        }

        public User Register(User user)
        {
            var existingUser = _users.Find(u => u.Username == user.Username).FirstOrDefault();

            if (existingUser != null)
            {
                throw new ApplicationException($"Username '{user.Username}' is already taken.");
            }
            else
            {
                _users.InsertOne(user);
            }

            return user;
        }

        public User Authenticate(string username, string password)
        {
            var user = _users.Find(u => u.Username == username && u.Password == password).FirstOrDefault();

            return user;
        }

    }
}