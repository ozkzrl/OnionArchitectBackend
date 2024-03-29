using Microsoft.EntityFrameworkCore;
using GymSpotterAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using GymSpotterAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.UI;
using GymSpotterAPI.Application.Abstractions.Token;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Configuration;

namespace GymSpotterAPI.Persistence
{
    public static class ServiceRegistration
    {

        public static void AddPersistenceServices(this IServiceCollection services)
        {

            services.AddDbContext<GymSpotterAPIDbContext>(options => options.UseNpgsql(Configurations.ConnectionString));
            
            services.AddIdentity<AppUser, AppRole>(optins =>
            {

                optins.Password.RequiredLength = 3;
                optins.Password.RequireNonAlphanumeric = false;
                optins.Password.RequireDigit = false;
                optins.Password.RequireLowercase = false;
                optins.Password.RequireUppercase = false;


            }).AddEntityFrameworkStores<GymSpotterAPIDbContext>();
        }
    }
}



  