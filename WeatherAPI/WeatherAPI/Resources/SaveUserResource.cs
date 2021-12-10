using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Resources
{
    public class SaveUserResource
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string FavoriteCities { get; set; }
    }
}
