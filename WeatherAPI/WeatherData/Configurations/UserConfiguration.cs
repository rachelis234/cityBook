using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherCore.Models;

namespace WeatherData.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.Id);

            builder
                .Property(u => u.Id)
                .UseIdentityColumn();

            builder
                .Property(u => u.Name)
                .IsRequired();

            builder
                 .Property(u => u.Email)
                 .IsRequired();


            builder
                 .Property(u => u.FavoriteCities);
                 


            builder
                .ToTable("Users");
        }

    }
}
