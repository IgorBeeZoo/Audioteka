using Staff;

namespace Domain
{
    /// <summary>
    /// Класс жанр.
    /// </summary>
    public sealed class Genre : IEquatable<Genre>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Genre"/>.
        /// </summary>
        /// <param name="name"> Название полки. </param>
        /// <exception cref="ArgumentNullException">Если название <see langword="null"> </exception>.
        public Genre(string name)
        {
            this.Id = Guid.Empty;
            this.Name = name.TrimOrNull() ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; }


        /// <summary>
        /// Идентификатор.
        /// </summary>
        public ISet<Album> Albums{ get; } = new HashSet<Album>();

        /// <summary>
        /// Название полки.
        /// </summary>
        public string Name { get; }

        /// <inheritdoc/>
        public bool Equals(Genre? other)
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
            return this.Equals(obj as Genre);
        }

        /// <inheritdoc/>
        public override int GetHashCode() => this.Name.GetHashCode();
    }
}
