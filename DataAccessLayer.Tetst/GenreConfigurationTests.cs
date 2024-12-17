// <copyright file="ShelfConfigurationTests.cs" company="Бежук, Козлов, Горшков, Минаева, Литвиненкова">
// Copyright (c) Бежук, Козлов, Горшков, Минаева, Литвиненкова. All rights reserved.
// </copyright>

namespace DataAccessLayer.Tests
{
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Тесты для <see cref="DataAccessLayer.Configurations.GenreConfigurationTests"/>.
    /// </summary>
    [TestFixture]
    internal sealed class GenreConfigurationTests : BaseConfigurationTests
    {
        [TearDown]
        public void TearDown()
        {
            this.DataContext.ChangeTracker.Clear();
        }

        [Test]
        public void AddEntityToDatabase_Success()
        {
            // arrange
            var genre = new Genre("Тестовый жанр");

            // act
            _ = this.DataContext.Add(genre);
            _ = this.DataContext.SaveChanges();
            this.DataContext.ChangeTracker.Clear();

            // assert
            var result = this.DataContext.Find<Genre>(genre.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Name, Is.EqualTo(genre.Name));
        }
    }
}