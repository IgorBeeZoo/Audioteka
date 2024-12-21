// <copyright file="IEntity.cs" company="Бежук, Козлов, Горшков, Минаева, Литвиненкова">
// Copyright (c) Бежук, Козлов, Горшков, Минаева, Литвиненкова. All rights reserved.
// </copyright>

namespace Domain
{
    using System;

    /// <summary>
    /// Интерфейс базовой сущности.
    /// </summary>
    /// <typeparam name="TEntity"> Тип конкретной сущности. </typeparam>
    public interface IEntity<TEntity> : IEquatable<TEntity>
        where TEntity : class, IEntity<TEntity>
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        Guid Id { get; }
    }
}