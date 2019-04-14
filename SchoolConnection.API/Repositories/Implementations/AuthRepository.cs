using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SchoolConnection.API.Data;
using SchoolConnection.API.Models;
using SchoolConnection.API.Repositories.Interfaces;

namespace SchoolConnection.API.Repositories.Implementations
{
    public class AuthRepository : IAuthRepository
    {
        private DataContext _context;
        private IConfiguration _config;

        public AuthRepository(DataContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public async Task<User> Login(string name, string password)
        {
            var userFromBase = await _context.Users.FirstOrDefaultAsync(x => x.Name == name);
            if(userFromBase == null)
                return null;
            
            if(!VerifyPasswordHash(password, userFromBase.PasswordHash, userFromBase.PasswordSalt))
                return null;
            return userFromBase;
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for(var i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            
            CreatePasswordHash(out passwordHash, out passwordSalt, password);

            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
            
        }

        private void CreatePasswordHash(out byte[] passwordHash, out byte[] passwordSalt, string password)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string name)
        {
            if(await _context.Users.AnyAsync(x => x.Name == name))
                return true;
            return false;
        }

        public SecurityTokenDescriptor GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var claims = new[] 
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            return new SecurityTokenDescriptor 
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

        }
    }
}