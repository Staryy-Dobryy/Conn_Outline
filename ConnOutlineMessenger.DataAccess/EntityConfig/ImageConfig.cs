using ConnOutlineMessenger.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnOutlineMessenger.EntityConfig
{
    public class ImageConfig : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.ImageData).HasMaxLength(2097152); // 2097152 - 2Mb
        }
    }
}
