// <copyright file="Shelf.cs" company="Бежук, Козлов, Горшков, Минаева, Литвиненкова">
// Copyright (c) Бежук, Козлов, Горшков, Минаева, Литвиненкова. All rights reserved.
// </copyright>

namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DataAccessLayer;
    using Domain;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Репозиторий для класса <see cref="Domain.Author"/>.
    /// </summary>
    public sealed class AuthorRepository : BaseRepository<Author>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AuthorRepository"/>.
        /// </summary>
        /// <param name="dataContext">Контекст доступа к данным.</param>
        /// <exception cref="ArgumentNullException">
        /// В случае если <paramref name="dataContext"/> – <see langword="null"/>.
        /// </exception>
        public AuthorRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        /// <summary>
        /// Получает всех авторов.
        /// </summary>
        /// <returns>Авторы.</returns>
        public override IQueryable<Author> GetAll()
        {
            return this.DataContext.Authors
                .Include(author => author.Albums);
        }

        /// <summary>
        /// Найти идентификатор автора по его фамилии.
        /// </summary>
        /// <param name="familyName">Фамилия автора.</param>
        /// <returns>Идентификатор.</returns>
        public Guid? GetIdByName(string familyName)
        {
            return this.Find(author => author.FamilyName == familyName)?.Id;
        }

        /// <summary>
        /// Получить список альбомов автора по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Альбомы автора.</returns>
        public ISet<Album> GetBooksByAuthorId(Guid id) => this.Get(id)?.Albums ?? new HashSet<Album>();

    }
}
