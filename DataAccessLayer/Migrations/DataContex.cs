// <copyright file="DataContex.cs" company="Бежук, Козлов, Горшков, Минаева, Литвиненкова">
// Copyright (c) Бежук, Козлов, Горшков, Минаева, Литвиненкова. All rights reserved.
// </copyright>

using System.Reflection;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Migrations
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref=DataContex">"/>
    /// </summary>
    public sealed class DataContex : DbContext
    {
        public DataContex()
        { 
        }

        public DataContex(DbContextOptions<DataContex> options):base(options) 
        {
        }

        /// <summary>
        /// Альбомы.
        /// </summary>
        public DbSet<Album> Albums { get; } = default!;

        /// <summary>
        /// Авторы.
        /// </summary>
        public DbSet<Album> Authors { get; } = default!;

        /// <summary>
        /// Жанры.
        /// </summary>
        public DbSet<Genre> Genres { get; } = default!;

        /// <summary>
        /// Полки.
        /// </summary>
        public DbSet<Shelf> Shelves { get; } = default!;

        /// <summary>
        /// Полки.
        /// </summary>
        public DbSet<Song> Songs { get; } = default!;

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=1;Host=localhost;Port=5432;Database=Library;");
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
