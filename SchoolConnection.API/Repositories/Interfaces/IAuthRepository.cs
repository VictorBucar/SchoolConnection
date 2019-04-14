using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using SchoolConnection.API.Models;

namespace SchoolConnection.API.Repositories.Interfaces
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);
         Task<User> Login(string name, string password);
         Task<bool> UserExists(string name);
         SecurityTokenDescriptor GenerateToken(User user);
    }
}