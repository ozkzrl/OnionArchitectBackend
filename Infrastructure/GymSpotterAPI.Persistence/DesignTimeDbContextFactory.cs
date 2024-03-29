using GymSpotterAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSpotterAPI.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<GymSpotterAPIDbContext>
    {
        public GymSpotterAPIDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<GymSpotterAPIDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configurations.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
