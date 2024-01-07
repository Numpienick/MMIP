using MMIP.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMIP.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public Task<User?> GetUserAsync(string email);
    }
}
