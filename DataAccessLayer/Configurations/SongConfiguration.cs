// <copyright file="SongConfiguration.cs" company="Бежук, Козлов, Горшков, Минаева, Литвиненкова">
// Copyright (c) Бежук, Козлов, Горшков, Минаева, Литвиненкова. All rights reserved.
// </copyright>

namespace DataAccessLayer.Configurations
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public sealed class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            _ = builder.HasKey(song => song.Id);
            _ = builder.Property(song => song.SongName)
                .HasMaxLength(50)
                .IsRequired();
            _ = builder.Property(song => song.SongDuration)
                .IsRequired();
        }
    }
}
