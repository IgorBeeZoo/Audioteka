// <copyright file="ShelfConfigurationTests.cs" company="Бежук, Козлов, Горшков, Минаева, Литвиненкова">
// Copyright (c) Бежук, Козлов, Горшков, Минаева, Литвиненкова. All rights reserved.
// </copyright>

namespace DataAccessLayer.Tests
{
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Тесты для <see cref="DataAccessLayer.Configurations.ShelfConfiguration"/>.
    /// </summary>
    [TestFixture]
    internal sealed class ShelfConfigurationTests : BaseConfigurationTests
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
            var shelf = new Shelf("Тестовая полка");

            // act
            _ = this.DataContext.Add(shelf);
            _ = this.DataContext.SaveChanges();
            this.DataContext.ChangeTracker.Clear();

            // assert
            var result = this.DataContext.Find<Shelf>(shelf.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Name, Is.EqualTo(shelf.Name));
        }
    }
}