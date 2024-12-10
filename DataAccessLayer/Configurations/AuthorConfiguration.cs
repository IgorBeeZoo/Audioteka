// <copyright file="AuthorConfiguration.cs" company="Бежук, Козлов, Горшков, Минаева, Литвиненкова">
// Copyright (c) Бежук, Козлов, Горшков, Минаева, Литвиненкова. All rights reserved.
// </copyright>

namespace DataAccessLayer.Configurations
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public sealed class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            _ = builder.HasKey(author => author.Id);

            _ = builder.Property(author => author.FamilyName)
               .HasMaxLength(50)
               .IsRequired();

            _ = builder.Property(author => author.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            _ = builder.Property(author => author.PatronicName)
                .HasMaxLength(50)
                .IsRequired(false);

            _ = builder.Property(author => author.DateBirth)
                .IsRequired(false);

            _ = builder.Property(author => author.DateDeath)
                .IsRequired(false);
        }
    }
}
