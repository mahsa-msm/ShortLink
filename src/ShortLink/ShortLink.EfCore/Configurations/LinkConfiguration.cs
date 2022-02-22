using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShortLink.Domain.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLink.EfCore.Configurations
{
    public class LinkConfiguration : IEntityTypeConfiguration<Link>
    {
        public void Configure(EntityTypeBuilder<Link> builder)
        {
            builder.ToTable(nameof(Link));
            builder.Property(c => c.MainLink).IsRequired();
            builder.Property(c => c.ShortLink).HasMaxLength(20).IsRequired();
            builder.HasKey(c => c.Id);
        }
    }
}
