using ConnOutlineMessenger.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnOutlineMessenger.DataAccess.Entities
{
    public class Friend : IdColumn
    {
        public uint UserId { get; set; }
        public uint FriendUserId { get; set; }
        public virtual User FriendUser { get; set; }
    }
}
