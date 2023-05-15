using ConnOutlineMessenger.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ConnOutlineMessenger.EntityConfig
{
    public class MessageConfig : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
        }
    }
}
