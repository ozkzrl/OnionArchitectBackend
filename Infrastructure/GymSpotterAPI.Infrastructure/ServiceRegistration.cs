using GymSpotterAPI.Application.Abstractions.Token;
using GymSpotterAPI.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using GymSpotterAPI.Infrastructure;
using MediatR;

namespace GymSpotterAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
        }

    }
}
