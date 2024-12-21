﻿// <copyright file="Shelf.cs" company="Бежук, Козлов, Горшков, Минаева, Литвиненкова">
// Copyright (c) Бежук, Козлов, Горшков, Минаева, Литвиненкова. All rights reserved.
// </copyright>

namespace Domain
{
    using System;
    using System.Collections.Generic;
    using Staff;

    /// <summary>
    /// Полка.
    /// </summary>
    public sealed class Shelf : Entity<Shelf>, IEquatable<Shelf>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Shelf"/>.
        /// </summary>
        /// <param name="name"> Название полки. </param>
        /// <exception cref="ArgumentNullException">Если название <see langword="null"> </exception>.
        public Shelf(string name)
        {
            this.Id = Guid.Empty;
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Название полки.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Ссылка на класс Album.
        /// </summary>
        public ISet<Album> Albums { get; } = new HashSet<Album>();

        /// <inheritdoc/>
        public bool Equals(Shelf? other)
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
            return this.Equals(obj as Shelf);
        }

        /// <inheritdoc/>
        public override int GetHashCode() => this.Name.GetHashCode();
    }
}
