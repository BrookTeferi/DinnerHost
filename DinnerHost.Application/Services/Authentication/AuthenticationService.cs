

using DinnerHost.Application.Common.Authentication;
using DinnerHost.Application.Persistance;
using DinnerHost.Domain.Entities;

namespace DinnerHost.Application.Services.Authentication
{
  
    public class AuthenticationService : IAuthenticationService 
    {
        private readonly IJWTTokenGenerator _jWTTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJWTTokenGenerator jWTTokenGenerator,IUserRepository userRepository)
        {
            _jWTTokenGenerator = jWTTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            //check if the user exists 
            if(_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("User with given email already exists.");
            }

            //create user(generate unique Id)
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };


            //create JWT token 
           

            var token = _jWTTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
            
        }

        public AuthenticationResult Login(string email, string password)
        {
            // check if the user exists
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User with given email doesnot exists.");
            }


            // validate the password 
            if(user.Password != password)
            {
                throw new Exception("Invalid password.");
            }

            // create JWt token
            var token = _jWTTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);

        }
    }
}
