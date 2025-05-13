using App.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
                UseLazyLoadingProxies().
                UseSqlServer(this.GetJsonConnectionString("C:\\Users\\Haroun_Jlassi_OD\\Desktop\\OD\\.NET\\exemen\\Examen-Prestation\\Prototype\\App\\App.UI.Web\\appsettings.json"));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PrestationConiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
