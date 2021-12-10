using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherCore.Models;
using WeatherData.Configurations;

namespace WeatherData
{
    public class WeatherDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public WeatherDBContext(DbContextOptions<WeatherDBContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new UserConfiguration());
            builder.Entity<User>()
        .HasIndex(u => u.Email)
        .IsUnique();

        }
    }
}
