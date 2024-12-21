

namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DataAccessLayer;
    using Domain;
    using Microsoft.EntityFrameworkCore;
    /// <summary>
    /// Репозиторий для класса <see cref="Domain.Album"/>.
    /// </summary>
    public sealed class AlbumRepository : BaseRepository<Album>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AlbumRepository"/>.
        /// </summary>
        /// <param name="dataContext">Контекст доступа к данным.</param>
        /// /// <exception cref="ArgumentNullException">
        /// В случае если <paramref name="dataContext"/> – <see langword="null"/>.
        /// </exception>
        public AlbumRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        /// <summary>
        /// Найти название альбома по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Название альбома.</returns>
        public string? GetTitle(Guid id) => this.Find(album => album.Id == id)?.Name;

        /// <summary>
        /// Получает идентификатор по названию книги.
        /// </summary>
        /// <param name="name">Название книги.</param>
        /// <returns>Идентификатор.</returns>
        public Guid? GetId(string name) => this.Find(album => album.Name == name)?.Id;

        public override IQueryable<Album> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
