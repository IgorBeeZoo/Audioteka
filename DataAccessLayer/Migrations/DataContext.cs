﻿// <copyright file="DataContex.cs" company="Бежук, Козлов, Горшков, Минаева, Литвиненкова">
// Copyright (c) Бежук, Козлов, Горшков, Минаева, Литвиненкова. All rights reserved.
// </copyright>

namespace DataAccessLayer.Migrations
{
    using System.Reflection;
    using Domain;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref=DataContext">"/>
    /// </summary>
    public sealed class DataContext : DbContext
    {
        public DataContext(): base()
        { 
        }

        public DataContext(DbContextOptions<DataContext> options):base(options) 
        {
        }

        /// <summary>
        /// Альбомы.
        /// </summary>
        public DbSet<Author> Albums { get; init; } = default!;

        /// <summary>
        /// Авторы.
        /// </summary>
        public DbSet<Author> Authors { get; init; } = default!;

        /// <summary>
        /// Жанры.
        /// </summary>
        public DbSet<Genre> Genres { get; init; } = default!;

        /// <summary>
        /// Полки.
        /// </summary>
        public DbSet<Shelf> Shelves { get; init; } = default!;

        /// <summary>
        /// Полки.
        /// </summary>
        public DbSet<Song> Songs { get; init; } = default!;

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=1;Host=localhost;Port=5432;Database=Audioteka;");
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}