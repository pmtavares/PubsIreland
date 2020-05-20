using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Pub> Login(string username, string password)
        {
            var pub = await _context.Pubs.FirstOrDefaultAsync(x => x.Username == username);

            if(pub == null)
            {
                return null;
            }

            //compare password
            if(!VerifyPasswordHash(password, pub.PasswordHash, pub.PasswordSalt))
            {
                return null;
            }

            return pub;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for(int i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        public async Task<Pub> RegisterPubAsync(Pub pub, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            pub.PasswordHash = passwordHash;
            pub.PasswordSalt = passwordSalt;

            await _context.Pubs.AddAsync(pub);
            await _context.SaveChangesAsync();

            return pub;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

               
        }

        public async Task<bool> UserExists(string username)
        {
            if(await _context.Pubs.AnyAsync(x => x.Username == username))
            {
                return true;
            }
            return false;
        }
    }
}
