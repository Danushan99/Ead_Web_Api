using Microsoft.AspNetCore.Mvc;
using Ticket_Reservation_system.Models.userModel;
using Ticket_Reservation_system.Models.UserModel;
using Ticket_Reservation_system.Services.UserService;


namespace Ticket_Reservation_system.Controllers.UserController
{
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            try
            {
                // Attempt to register the user
                var registeredUser = _userService.Register(user);
                return Ok($"User {registeredUser.Username} has been registered successfully.");
            }
            catch (ApplicationException ex)
            {
                // Return a 400 Bad Request with an error message if registration fails
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginRequest userLogin)
        {
            // Authenticate the user based on the provided username and password
            var authenticatedUser = _userService.Authenticate(userLogin.Username, userLogin.Password);

            if (authenticatedUser == null)
            {
                // Return a 401 Unauthorized if authentication fails
                return Unauthorized("Invalid username or password.");
            }

            // You can generate a JWT token here and return it to the client for further authentication.
            // For simplicity, I'll just return a success message.
            //return Ok($"User {authenticatedUser.Username} has been authenticated successfully.");

            var response = new
            {
                User = new
                {
                    authenticatedUser.Id,
                    authenticatedUser.Username,
                    authenticatedUser.UserType,
                    authenticatedUser.IsActive
                }
            };

            return Ok(response);
        }
    }
}