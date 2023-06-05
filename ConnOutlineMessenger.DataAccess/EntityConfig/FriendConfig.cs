using ConnOutlineMessenger.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnOutlineMessenger.DataAccess.Entities;

namespace ConnOutlineMessenger.DataAccess.EntityConfig
{
    public class FriendConfig : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
        }
    }
}
