// <copyright file="Author.cs" company="Бежук, Козлов, Горшков, Минаева, Литвиненкова">
// Copyright (c) Бежук, Козлов, Горшков, Минаева, Литвиненкова. All rights reserved.
// </copyright>

namespace Domain
{
    using Staff;

    /// <summary>
    /// Класс Автор.
    /// </summary>
    public sealed class Author : IEquatable<Author>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Domain.Author"/>.
        /// </summary>
        /// <param name="familyName"> Фамилия.</param>
        /// <param name="firstName"> Имя. </param>
        /// <param name="patronicName"> Отчество. </param>
        /// <param name="dateBirth"> Дата рождения. </param>
        /// <param name="dateDeath"> Дата смерти. </param>
        /// <exception cref="ArgumentNullException">Если имя или фамилия <see langword="null"/>.</exception>
        public Author(
            string familyName,
            string firstName,
            string? patronicName = null,
            DateOnly? dateBirth = null,
            DateOnly? dateDeath = null)
        {
            this.Id = Guid.Empty;
            this.FamilyName = familyName.TrimOrNull() ?? throw new ArgumentNullException(nameof(familyName));
            this.FirstName = firstName.TrimOrNull() ?? throw new ArgumentNullException(nameof(firstName));
            this.PatronicName = patronicName?.TrimOrNull();
            this.DateBirth = dateBirth;
            this.DateDeath = dateDeath;
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string FamilyName { get; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string? PatronicName { get; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateOnly? DateBirth { get; }

        /// <summary>
        /// Дата смерти.
        /// </summary>
        public DateOnly? DateDeath { get; }

        /// <summary>
        /// Альбомы автора.
        /// </summary>
        public ISet<Author> Albums { get; } = new HashSet<Author>();

        /// <inheritdoc/>
        public bool Equals(Author? other)
        {
            return other is not null
                && this.FamilyName == other.FamilyName
                && this.FirstName == other.FirstName
                && this.PatronicName == other.PatronicName
                && this.DateBirth == other.DateBirth
                && this.DateDeath == other.DateDeath;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Author);
         }

        /// <inheritdoc/>
        public override int GetHashCode() =>
            HashCode.Combine(this.FamilyName, this.FirstName, this.PatronicName, this.DateBirth, this.DateDeath);

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.PatronicName is null
            ? $"{this.FamilyName} {this.FirstName} {this.PatronicName}"
            : $"{this.FamilyName} {this.FirstName}";
        }
    }
}
