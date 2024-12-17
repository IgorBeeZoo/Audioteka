// <copyright file="AlbumConfigurationTest.cs" company="Бежук, Козлов, Горшков, Минаева, Литвиненкова">
// Copyright (c) Бежук, Козлов, Горшков, Минаева, Литвиненкова. All rights reserved.
// </copyright>

namespace DataAccessLayer.Tests
{
    using System.Xml.Linq;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Тесты для <see cref="DataAccessLayer.Configurations.SongConfigurationTests"/>.
    /// </summary>
    [TestFixture]
    internal sealed class SongConfigurationTests : BaseConfigurationTests
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
            var song = new Song("Тестовый альбом", 180);

            // act
            _ = this.DataContext.Add(song);
            _ = this.DataContext.SaveChanges();
            this.DataContext.ChangeTracker.Clear();

            // assert
            var result = this.DataContext.Find<Song>(song.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.SongName, Is.EqualTo(song.SongName));
        }
    }
}