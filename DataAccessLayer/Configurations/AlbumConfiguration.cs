﻿namespace DataAccessLayer.Configurations
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public sealed class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            _ = builder.HasKey(album => album.Id);
            _ = builder.Property(album => album.Name)
                .HasMaxLength(50)
                .IsRequired();

            _ = builder.Property(album => album.DateRelease)
                .HasMaxLength(50)
                .IsRequired();

            _ = builder.HasOne(album => album.Shelf)
                .WithMany(shelf => shelf.Albums)
                .IsRequired();

            _ = builder.HasOne(album => album.Author)
                .WithMany(author => author.Albums)
                .IsRequired();

            _ = builder.HasOne(album => album.Genre)
                .WithMany(genre => genre.Albums)
                .IsRequired();

            _ = builder.HasMany(album => album.Songs)
                .WithOne(song => song.Album)
                .IsRequired();

        }
    }
}
