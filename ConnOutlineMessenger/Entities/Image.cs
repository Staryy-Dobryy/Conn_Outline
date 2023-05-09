namespace ConnOutlineMessenger.Entities
{
    public class Image : IdColumn
    {
        public string Link { get; set; }
        public byte[]? ImageData { get; set; }
    }
}
