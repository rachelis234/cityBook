using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherCore;
using WeatherCore.Repositories;
using WeatherData.Repositories;

namespace WeatherData
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WeatherDBContext _context;
        private UserRepository _userRepository;

        public UnitOfWork(WeatherDBContext context)
        {
            this._context = context;
        }

        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);


        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

