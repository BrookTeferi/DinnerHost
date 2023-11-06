using DinnerHost.Application.Common.Authentication;
using DinnerHost.Application.Common.Services;
using DinnerHost.Application.Persistance;
using DinnerHost.Infrastructure.Authentication;
using DinnerHost.Infrastructure.Persistance;
using DinnerHost.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;



namespace DinnerHost.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            var jwtSettings = new JwtSettings();
            configuration.GetSection(JwtSettings.SectionName).Bind(jwtSettings);
            services.AddSingleton(jwtSettings);

            services.AddSingleton<IJWTTokenGenerator, JWTTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
 


 