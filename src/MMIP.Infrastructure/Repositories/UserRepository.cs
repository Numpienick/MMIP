using MMIP.Application.Interfaces.Repositories;
using MMIP.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MMIP.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataRepository<User> _repository;

        public UserRepository(IDataRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<User?> GetUserAsync(string email)
        {
            return await _repository.Entities.Where(u => u.Email == email).SingleOrDefaultAsync();
        }
    }
}
