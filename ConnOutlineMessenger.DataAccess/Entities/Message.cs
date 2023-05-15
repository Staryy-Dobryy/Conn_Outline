namespace ConnOutlineMessenger.Entities
{
    public class Message : IdColumn
    {
        public string MessageText { get; set; }
        public DateTime SendTime { get; set; }
        public uint SenderId { get; set; }
        public uint CurrentChatId { get; set; }
        public virtual ICollection<Image>? MessageImg { get; set; }
        public virtual User Sender { get; set; }
        public virtual Chat CurrentChat { get; set; }
    }
}
