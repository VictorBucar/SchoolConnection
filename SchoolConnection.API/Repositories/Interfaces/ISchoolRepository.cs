using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolConnection.API.Models;

namespace SchoolConnection.API.Repositories.Interfaces
{
    public interface ISchoolRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int id);

    }
}