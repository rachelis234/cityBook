using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherCore;
using WeatherCore.Models;
using WeatherCore.Services;

namespace WeatherServices.Services
{
    public class UserService:IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<User> CreateUser(User newUser)
        {
            if (_unitOfWork.Users.Find(u => u.Email == newUser.Email).Count()>0)
            {
                return null;
            }
            await _unitOfWork.Users.AddAsync(newUser);
            await _unitOfWork.CommitAsync();
            return newUser;
        }

        //public async Task DeleteUser(User user)
        //{
        //    _unitOfWork.Users.Remove(user);
        //    await _unitOfWork.CommitAsync();
        //}

        //public async Task<IEnumerable<Music>> GetAllWithArtist()
        //{
        //    return await _unitOfWork.Musics
        //        .GetAllWithArtistAsync();
        //}

        public async Task<User> GetUserByEmail(string email)
        {
            return await _unitOfWork.Users.GetByEmailAsync
                (email);
        }

        //public async Task<IEnumerable<User>> GetMusicsByArtistId(int artistId)
        //{
        //    return await _unitOfWork.Musics
        //        .GetAllWithArtistByArtistIdAsync(artistId);
        //}

        public async Task UpdateUser(User userToBeUpdated, User user)
        {
            userToBeUpdated.Name = user.Name;
            userToBeUpdated.FavoriteCities = user.FavoriteCities;

            await _unitOfWork.CommitAsync();
        }
        public async Task<User> GetUserById(int id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }

    }
}
