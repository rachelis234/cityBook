using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeatherCore.Models;
using WeatherCore.Repositories;

namespace WeatherData.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(WeatherDBContext context)
            : base(context)
        { }

        //public async Task<IEnumerable<User>> GetAllWithArtistAsync()
        //{
        //    return await WeatherDBContext.Users
        //        .Include(m => m.Artist)
        //        .ToListAsync();
        //}

        public async Task<User> GetByEmailAsync(string email)
        {
            return await WeatherDBContext.Users
                .SingleOrDefaultAsync(u => u.Email == email); ;
        }

        //public async Task<IEnumerable<Music>> GetAllWithArtistByArtistIdAsync(int artistId)
        //{
        //    return await MyMusicDbContext.Musics
        //        .Include(m => m.Artist)
        //        .Where(m => m.ArtistId == artistId)
        //        .ToListAsync();
        //}

        private WeatherDBContext WeatherDBContext
        {
            get { return Context as WeatherDBContext; }
        }
    }
}
