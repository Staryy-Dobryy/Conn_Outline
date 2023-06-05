using ConnOutlineMessenger.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnOutlineMessenger.BuisnessLogic.Models
{
    public class GetFriendsModel
    {
        public ICollection<User> Friends { get; set; }
        public GetFriendsModel() { }
        public GetFriendsModel(ICollection<User> friends)
        {
            Friends = friends;
        }
    }
}
