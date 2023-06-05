using ConnOutlineMessenger.DataAccess.Entities;

namespace ConnOutlineMessenger.Entities
{
    public class User : IdColumn
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public DateTime RegDateTime { get; set; }
        public virtual Image? UserIcon { get; set; }
        public virtual ICollection<Friend>? Friends { get; set; }
        public virtual ICollection<Chat>? Chats { get; set; }
    }
}
