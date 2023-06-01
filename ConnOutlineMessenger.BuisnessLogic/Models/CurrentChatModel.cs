using ConnOutlineMessenger.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnOutlineMessenger.BuisnessLogic.Models
{
    public class CurrentChatModel
    {
        public uint ChatId { get; set; }
        public string ChatName { get; set; }
        public DateTime CreationTime { get; set; }
        public ICollection<User> Members { get; set; }
        public ICollection<Message>? Messages { get; set; }
    }
}
