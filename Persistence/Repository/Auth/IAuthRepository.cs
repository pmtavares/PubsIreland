using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository.Auth
{
    public interface IAuthRepository
    {

        Task<Pub> RegisterPubAsync(Pub pub, string password);

        Task<Pub> Login(string username, string password);

        Task<bool> UserExists(string username);
    }
}
