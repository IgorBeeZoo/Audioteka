// <copyright file="AuthorRepositoryTests.cs" company="Бежук, Козлов, Горшков, Минаева, Литвиненкова">
// Copyright (c) Бежук, Козлов, Горшков, Минаева, Литвиненкова. All rights reserved.
// </copyright>

namespace Repository.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Domain;
    using NUnit.Framework;
    using Repository;
    using Repository.Tests;

    internal sealed class AuthorRepositotyTests
        : BaseReposytoryTests<AuthorRepository, Author>
    {
        [SetUp]
        public void Setup()
        {
            _ = this.DataContext.Database.EnsureCreated();
        }

        [TearDown]
        public void TearDown()
        {
            _ = this.DataContext.Database.EnsureDeleted();
        }

        [Test]
        public void Create_ValidData_Success()
        {
            var author = new Author("Эдмунд", "Шлярский");

            // act
            _ = this.Repository.Create(author);

            // assert
            var result = this.DataContext.Find<Author>(author.Id);

            Assert.That(result, Is.EqualTo(author));
        }

        [Test]
        public void Update_ValidData_Success()
        {
            // arrange
            var author = new Author("Эдмунд", "Шлярский");
            _ = this.DataContext.Add(author);
            _ = this.DataContext.SaveChanges();

            // act
            author.DateBirth = new DateOnly(1955, 09, 26);
            _ = this.Repository.Update(author);

            // assert
            var result = this.DataContext.Find<Author>(author.Id)?.DateBirth;

            Assert.That(result, Is.EqualTo(author.DateBirth));
        }

        public void Delete_ValidData_Success()
        {
            // arrange
            var author = new Author("Эдмунд", "Шлярский", "Мечеславович");
            _ = this.DataContext.Add(author);
            _ = this.DataContext.SaveChanges();

            // act
            _ = this.Repository.Delete(author);

            // assert
            var result = this.DataContext.Find<Author>(author.Id);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetIdByName_FamilyName_Success()
        {
            // arrange
            var familyName = "Шклярский";
            var authors = new[]
            {
                new Author(new (familyName, "Эдмунд", "Мечеславович")),
                new Author(new (familyName, "Алексей", "Константинович")),
                new Author(new (familyName, "Алексей", "Николаевич")),
            };

            this.DataContext.AddRange(authors);
            _ = this.DataContext.SaveChanges();
            this.DataContext.ChangeTracker.Clear();

            // act
            var result = this.Repository.GetIdByName(familyName);

            Assert.That(
               authors.Select(author => author.Id),
               Has.One.EqualTo(result),
               message: "Полученный идентификатор входит в множество идентификаторов целевых авторов");
        }

        [Test]
        public void GetBooksById_ValidData_Success()
        {
            var author = new Author("Эдмунд", "Шлярский");
            var shelf = new Shelf("1");

            var albums = new HashSet<Album>
            {
                new ("Говорит и показывает", 2003, "1", shelf, author),
            };

            _ = this.DataContext.Add(author);
            _ = this.DataContext.SaveChanges();
            this.DataContext.ChangeTracker.Clear();

            // act
            var result = this.Repository.GetBooksByAuthorId(author.Id);

            // assert
            Assert.That(result, Is.EquivalentTo(albums));
        }
    }
    }