using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configurations
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public sealed class AlbumConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            _ = builder.HasKey(album => album.Id);
            _ = builder.Property(album => album.Name)
                .IsRequired();
            _ = builder.Property(album => album.Date_Release)
                .IsRequired();
            _ = builder.Property(album => album.Shelf)
                .IsRequired(false);
            _ = builder.Property(album => album.Author)
                .IsRequired();
            _ = builder.Property(album => album.Genre)
                .IsRequired();
            _ = builder.Property(album => album.Songs)
                .WithMany(album => album.Albums);
        }
    }
}
