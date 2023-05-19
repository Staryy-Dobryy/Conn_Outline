using ConnOutlineMessenger.DataAccess.Interfaces;
using ConnOutlineMessenger.DBstur;
using ConnOutlineMessenger.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnOutlineMessenger.DataAccess.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : IdColumn
    {
        private bool _disposedValue;
        protected readonly DataBaseContext _db;
        public BaseRepository(DataBaseContext db) => _db = db;

        public virtual async Task CreateAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(uint id)
        {
            var model = await _db.Set<T>().FindAsync(id);
            if (model != null) _db.Set<T>().Remove(model);
            await _db.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>();
        }

        public async Task<T?> GetByIdAsync(uint id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        protected void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
