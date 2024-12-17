// <copyright file="AlbumConfigurationTest.cs" company="Бежук, Козлов, Горшков, Минаева, Литвиненкова">
// Copyright (c) Бежук, Козлов, Горшков, Минаева, Литвиненкова. All rights reserved.
// </copyright>

namespace DataAccessLayer.Tests
{
    using System.Xml.Linq;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Тесты для <see cref="DataAccessLayer.Configurations.AuthorConfiguration"/>.
    /// </summary>
    [TestFixture]
    internal sealed class AuthorConfigurationTests : BaseConfigurationTests
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
            var author = new Author("Толстой", "Лев");

            // act
            _ = this.DataContext.Add(author);
            _ = this.DataContext.SaveChanges();
            this.DataContext.ChangeTracker.Clear();

            // assert
            var result = this.DataContext.Find<Author>(author.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.FamilyName, Is.EqualTo(author.FamilyName));
            Assert.That(result!.FirstName, Is.EqualTo(author.FirstName));
            Assert.That(result!.PatronicName, Is.EqualTo(author.PatronicName));
        }
    }
}