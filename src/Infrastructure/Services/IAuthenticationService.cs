using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTO;
using Shared.Entities;

namespace Infrastructure.Services
{
    public interface IAuthenticationService
    {
        Task<RegistrationResponse> RegisterUser(User userForRegistration);
    }
}
