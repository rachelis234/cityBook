using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherCore.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //[Index(IsUnique = true)]
        public string Email { get; set; }
        public string FavoriteCities { get; set; }

    }
}
