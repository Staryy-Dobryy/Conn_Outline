using ConnOutlineMessenger.Entities;
using ConnOutlineMessenger.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ConnOutlineMessenger.DBstur
{
    public class EFcontext : DbContext
    {
        public EFcontext(DbContextOptions<EFcontext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Image> Images { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new ChatConfig());
            modelBuilder.ApplyConfiguration(new MessageConfig());
            modelBuilder.ApplyConfiguration(new ImageConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
