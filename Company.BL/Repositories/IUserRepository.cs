using Company.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BL.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<User> PostUser(User dataUser);
        Task<User> UpdateUser(int id, User dataUser);
        Task<string> DeleteUserById(int id);
    }
}
