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
            builder.Property(x => x.Password).IsRequired().HasMaxLength(25);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(20);

            builder
                .HasMany(x => x.Chats)
                .WithMany(x => x.Members);
        }
    }
}
