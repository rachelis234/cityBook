using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherCore.Models;

namespace WeatherCore.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        //Task<IEnumerable<User>> GetAllWithFavoriteCitiesAsync();
        Task<User> GetByEmailAsync(string email);
        //Task<IEnumerable<User>> GetAllWithArtistByArtistIdAsync(int artistId);
    }
}
