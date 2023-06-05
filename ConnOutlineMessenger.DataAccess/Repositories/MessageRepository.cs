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
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(DataBaseContext db) : base(db) { }

        public async Task<Message> CreateAndReturnAsync(Message messageEntity)
        {
            var message = await _db.Set<Message>().AddAsync(messageEntity);
            await _db.SaveChangesAsync();
            return message.Entity;
        }
    }
}
