using DinnerHost.Application.Common.Authentication;
using DinnerHost.Application.Common.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace DinnerHost.Infrastructure.Authentication
{
    public class JWTTokenGenerator : IJWTTokenGenerator
    {
       
        private readonly IDateTimeProvider _dateTimeProvider; 
        public string GenerateToken(Guid userId, string firstName, string lastName)
        {
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super-secret-key")),
          SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                 new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                 new Claim(JwtRegisteredClaimNames.GivenName, firstName),
                 new Claim(JwtRegisteredClaimNames.FamilyName,lastName),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                

             };

            var securityToken= new JwtSecurityToken(
                issuer :"HostDinner",
                expires:_dateTimeProvider.UtcNow.AddMinutes(60),
                claims:claims,
                signingCredentials:signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken); 
        }
    }
}
