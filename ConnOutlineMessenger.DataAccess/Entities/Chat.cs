namespace ConnOutlineMessenger.Entities
{
    public class Chat : IdColumn
    {
        public string ChatName { get; set; }
        public DateTime CreationTime { get; set; }
        public virtual ICollection<User> Members { get; set; }
        public virtual ICollection<Message>? Messages { get; set; }
    }
}
