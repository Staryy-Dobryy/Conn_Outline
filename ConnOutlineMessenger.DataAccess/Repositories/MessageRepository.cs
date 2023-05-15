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
    public class MessageRepository : IRepository<Message>
    {
        private bool _disposedValue;
        private readonly DataBaseContext _db;
        public MessageRepository(DataBaseContext db) => _db = db;

        public async Task Create(Message entity)
        {
            await _db.Messages.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(uint id)
        {
            var message = await _db.Messages.FindAsync(id);
            if (message != null) _db.Messages.Remove(message);
            await _db.SaveChangesAsync();
        }

        public IEnumerable<Message> GetAll()
        {
            return _db.Messages;
        }

        public async Task<Message?> GetById(uint id)
        {
            return await _db.Messages.FindAsync(id);
        }

        public async Task Update(Message entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
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
