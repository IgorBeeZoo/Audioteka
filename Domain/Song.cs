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
        /// <param name="songDuration"> длительность трека. </param>

        public Song(
            string songName,
            int songDuration)

        {
            this.Id = Guid.Empty;
            this.SongName = songName.TrimOrNull() ?? throw new ArgumentNullException(nameof(songName));
            if (songDuration < 0)
            {
                throw new ArgumentNullException(nameof(songDuration));
            }

            this.SongDuration = songDuration;

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
        public int SongDuration { get; }


        /// <summary>
        /// Трек в альбоме.
        /// </summary>
        public Album? Album { get; }

        /// <inheritdoc/>
        public bool Equals(Song? other)
        {
            return other is not null
                && this.SongName == other.SongName
                && this.SongDuration == other.SongDuration;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Song);
        }

        /// <inheritdoc/>
        public override int GetHashCode() =>
            HashCode.Combine(this.SongName, this.SongDuration);

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.SongName} {this.SongDuration}";
        }
    }
}
