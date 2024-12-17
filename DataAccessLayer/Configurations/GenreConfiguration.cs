// <copyright file="GenreConfiguration.cs" company="Бежук, Козлов, Горшков, Минаева, Литвиненкова">
// Copyright (c) Бежук, Козлов, Горшков, Минаева, Литвиненкова. All rights reserved.
// </copyright>

namespace DataAccessLayer.Configurations
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public sealed class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Genre> builder) 
        {
            _ = builder.HasKey(genre => genre.Id);
            _ = builder.Property(genre => genre.Name)
               .HasMaxLength(50)
               .IsRequired();
        }
    }
}
