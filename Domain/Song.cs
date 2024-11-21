namespace Domain
{
    using Staff;

    /// <summary>
    /// Класс Песня.
    /// </summary>

 public sealed class Song : IEquatable<Song>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Song"/>.
        /// </summary>
        /// <param name="songName"> название трека.</param>
        /// <param name="songDura"> длительность трека. </param>
        
        public Song(
            string songName,
            int songDura)

        {
            this.Id = Guid.Empty;
            this.SongName = songName.TrimOrNull() ?? throw new ArgumentNullException(nameof(songName));
            this.SongDura = songDura.TrimOrNull() ?? throw new ArgumentNullException(nameof(songDura));

        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Название трека.
        /// </summary>
        public string SongName { get; }

        /// <summary>
        /// Длительность трека.
        /// </summary>
        public string SongDura { get; }


        /// <summary>
        /// Трек в альбоме.
        /// </summary>
        public ISet<Album> Albums { get; } = new HashSet<Album>();

        /// <inheritdoc/>
        public bool Equals(Song? other)
        {
            return other is not null
                && this.SongName == other.SongName
                && this.SongDura == other.SongDura

        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Song);
         }

        /// <inheritdoc/>
        public override int GetHashCode() =>
            HashCode.Combine(this.SongName, this.SongDura);

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.PatronicName is null
            ? $"{this.SongName} {this.SongDura}";
        }
    }
}

