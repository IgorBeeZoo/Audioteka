// <copyright file="AlbumConfigurationTest.cs" company="Бежук, Козлов, Горшков, Минаева, Литвиненкова">
// Copyright (c) Бежук, Козлов, Горшков, Минаева, Литвиненкова. All rights reserved.
// </copyright>

namespace DataAccessLayer.Tests
{
    using System.Xml.Linq;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Тесты для <see cref="DataAccessLayer.Configurations.AlbumConfigurationTests"/>.
    /// </summary>
    [TestFixture]
    internal sealed class AlbumConfigurationTests : BaseConfigurationTests
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
            var album = new Album("Тестовый альбом");

            // act
            _ = this.DataContext.Add(album);
            _ = this.DataContext.SaveChanges();
            this.DataContext.ChangeTracker.Clear();

            // assert
            var result = this.DataContext.Find<Album>(album.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Name, Is.EqualTo(album.Name));
        }
    }
}