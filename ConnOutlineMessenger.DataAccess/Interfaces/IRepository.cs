using ConnOutlineMessenger.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnOutlineMessenger.DataAccess.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<T?> GetByIdAsync(uint id);
        IEnumerable<T> GetAll();
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(uint id);
    }
}
