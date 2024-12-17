// <copyright file="ShelfConfiguration.cs" company="Бежук, Козлов, Горшков, Минаева, Литвиненкова">
// Copyright (c) Бежук, Козлов, Горшков, Минаева, Литвиненкова. All rights reserved.
// </copyright>

namespace DataAccessLayer.Configurations
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public sealed class ShelfConfiguration : IEntityTypeConfiguration<Shelf>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Shelf> builder) 
        {
            _ = builder.HasKey(shelf => shelf.Id);
            _ = builder.Property(shelf => shelf.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
