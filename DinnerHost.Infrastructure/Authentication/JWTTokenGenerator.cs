using DinnerHost.Application.Common.Authentication;
using DinnerHost.Application.Common.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace DinnerHost.Infrastructure.Authentication
{
    public class JWTTokenGenerator : IJWTTokenGenerator
    {
       
        private readonly IDateTimeProvider _dateTimeProvider; 
        private readonly JwtSettings _jwtSettings;

        public JWTTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettings)
        {
            _dateTimeProvider = dateTimeProvider;
            _jwtSettings = jwtSettings.Value;
        }

        public string GenerateToken(Guid userId, string firstName, string lastName)
        {
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
          SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                    new Claim(JwtRegisteredClaimNames.GivenName, firstName),
                    new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

            var securityToken = new JwtSecurityToken(
              issuer: _jwtSettings.Issuer,
              audience: _jwtSettings.Audience,
              expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
              claims: claims,
              signingCredentials: signingCredentials);


            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;
        }
    }
}
