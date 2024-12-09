

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

    }
}
