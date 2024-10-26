// <copyright file="Album.cs" company="Бежук И.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace Domain
{
    public sealed class Album : IEquatable<Album>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Album"/>.
        /// </summary>
        /// <param name="name"></param>
        public Album(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
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
        /// Количество песен в альбоме.
        /// </summary>

        public int Songs_Numbers { get; }

        /// <summary>
        /// Дата релиза альбома.
        /// </summary>
        public DateOnly Date_Release { get; }

        /// <summary>
        /// Автор.
        /// </summary>
        public ISet<Author> Author { get; set} = new HashSet<Author>();

        /// <inheritdoc/>

        // Присвоение нового имени при добавлении элемента.
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
