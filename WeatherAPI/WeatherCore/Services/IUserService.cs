using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherCore.Models;

namespace WeatherCore.Services
{
    public interface IUserService
    {
        //Task<IEnumerable<User>> GetAllWithArtist();
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserById(int id);

        //Task<IEnumerable<User>> GetUsersByCityId(int cityId);
        Task<User> CreateUser(User newUser);
        Task UpdateUser(User userToBeUpdated, User user);
        //Task DeleteUser(User user);
    }
}
