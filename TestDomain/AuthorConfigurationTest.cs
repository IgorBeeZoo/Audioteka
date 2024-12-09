// <copyright file="AlbumConfigurationTest.cs" company="Бежук, Козлов, Горшков, Минаева, Литвиненкова">
// Copyright (c) Бежук, Козлов, Горшков, Минаева, Литвиненкова. All rights reserved.
// </copyright>

namespace TestDomain
{
    using System.Xml.Linq;
    using Domain;
    using NUnit.Framework;

    internal class AuthorConfigurationTest
    {
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
                var name = new Name("Толстой", "Лев");
                var author = new Author(name);

                // act
                _ = this.DataContext.Add(author);
                _ = this.DataContext.SaveChanges();
                this.DataContext.ChangeTracker.Clear();

                // assert
                var result = this.DataContext.Find<Author>(author.Id);

                Assert.That(result, Is.Not.Null);
            }
        }
    }
}
