using ConnOutlineMessenger.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnOutlineMessenger.EntityConfig
{
    public class ChatConfig : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            builder
                .HasMany(x => x.Messages)
                .WithOne(x => x.CurrentChat)
                .HasForeignKey(x => x.CurrentChatId)
                .HasPrincipalKey(x => x.Id);
        }
    }
}
