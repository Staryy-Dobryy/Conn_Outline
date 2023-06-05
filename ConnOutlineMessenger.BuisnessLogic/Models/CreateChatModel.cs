using ConnOutlineMessenger.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnOutlineMessenger.BuisnessLogic.Models
{
    public class CreateChatModel
    {
        public string ChatName { get; set; }
        public List<uint> Members { get; set; }
        public ICollection<User> Friends { get; set; }
    }
}
