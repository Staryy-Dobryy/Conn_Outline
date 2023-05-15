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
        Task<User?> GetByUserName(string userName);
        Task<User?> GetByEmail(string email);
    }
}
