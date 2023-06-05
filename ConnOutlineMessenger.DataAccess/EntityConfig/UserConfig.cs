using ConnOutlineMessenger.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnOutlineMessenger.EntityConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(20);

            builder
                .HasMany(x => x.Chats)
                .WithMany(x => x.Members);

            builder
                .HasMany(x => x.Friends)
                .WithOne(x => x.FriendUser)
                .HasForeignKey(x => x.FriendUserId)
                .HasPrincipalKey(x => x.Id);
        }
    }
}
