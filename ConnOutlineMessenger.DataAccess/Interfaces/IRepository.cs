using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnOutlineMessenger.DataAccess.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<T?> GetById(uint id);
        IEnumerable<T> GetAll();
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(uint id);
    }
}
