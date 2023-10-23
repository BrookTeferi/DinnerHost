using DinnerHost.Application.Common.Authentication;
using DinnerHost.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace DinnerHost.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddSingleton<IJWTTokenGenerator, JWTTokenGenerator>();
            
            return services;
        }

    }
}
