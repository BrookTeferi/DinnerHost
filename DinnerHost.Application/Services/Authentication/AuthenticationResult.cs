

using DinnerHost.Domain.Entities;

namespace DinnerHost.Application.Services.Authentication
{
   public record AuthenticationResult(
       User User,
       string Token
       );
}
