// <copyright file="Album.cs" company="Бежук И.А., Козлов Я.А., Горшков В.***., Литвиненкова А.П., Минаева Е.***.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

using Staff;

namespace Domain
{
    public sealed class Album : IEquatable<Album>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Domain.Album"/>.
        /// </summary>
        /// <param name="name"></param>
        public Album(string name)
        {
            this.Id = Guid.Empty;
            this.Name = name.TrimOrNull() ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Имя альбома.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Дата релиза альбома.
        /// </summary>
        public DateOnly DateRelease { get; }

        /// <summary>
        /// Автор.
        /// </summary>
        public Author? Author { get; set; }

        /// <summary>
        /// Жанр.
        /// </summary>
        public Genre? Genre { get; set; }

        public Shelf? Shelf { get; set; }

        /// <summary>
        /// Песни.
        /// </summary>
        public ISet<Song> Songs { get; } = new HashSet<Song>();


        /// <inheritdoc/>
        public bool Equals(Album? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Name == other.Name;
        }

        /// <inheritdoc/>
        public override string ToString() => $"{this.Name}";

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Album);
        }

        /// <inheritdoc/>
        public override int GetHashCode() => this.Name.GetHashCode();

    }
}
