using GymSpotterAPI.Domain.Entities;
using GymSpotterAPI.Domain.Entities.Identity;
using GymSpotterAPI.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Apis.Analytics.v3.Data.Goal;

namespace GymSpotterAPI.Persistence.Contexts
{
    public class GymSpotterAPIDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public GymSpotterAPIDbContext(DbContextOptions options) : base(options)
        {




        }

        
        public DbSet<WorkOut> WorkOuts {  get; set; }
       
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // IdentityUserLogin sınıfının birincil anahtarını belirtin
            modelBuilder.Entity<IdentityUserLogin<string>>(b =>
            {
                b.HasKey(l => new { l.LoginProvider, l.ProviderKey });
            });

            // Diğer yapılandırmaları buraya ekleyebilirsiniz.
        }
    }
}
