using ConnOutlineMessenger.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnOutlineMessenger.DataAccess.Interfaces
{
    public interface IMessageRepository : IRepository<Message>
    {
        Task<Message> CreateAndReturnAsync(Message messageEntity);
    }
}
