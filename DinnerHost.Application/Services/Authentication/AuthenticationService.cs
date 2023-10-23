

using DinnerHost.Application.Common.Authentication;

namespace DinnerHost.Application.Services.Authentication
{
  
    public class AuthenticationService : IAuthenticationService 
    {
        private readonly IJWTTokenGenerator _jWTTokenGenerator;

        public AuthenticationService(IJWTTokenGenerator jWTTokenGenerator)
        {
            _jWTTokenGenerator = jWTTokenGenerator;
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            //check if the user exists 
            //create user(generate unique Id)
            //create JWT token 
            Guid userId = Guid.NewGuid();

            var token = _jWTTokenGenerator.GenerateToken(userId, firstName, lastName);

            return new AuthenticationResult(Guid.NewGuid(), firstName, lastName, email, token);
            
        }

        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(Guid.NewGuid(), "firstName", "lastname", email, "token");
        }
    }
}
