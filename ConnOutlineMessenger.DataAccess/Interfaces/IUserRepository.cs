using ConnOutlineMessenger.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnOutlineMessenger.DataAccess.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByUserNameAsync(string userName);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdWithDetailsAsync(uint id);
    }
}
