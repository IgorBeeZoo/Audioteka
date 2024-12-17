// <copyright file="AlbumTest.cs" company="Бежук, Козлов, Горшков, Минаева, Литвиненкова">
// Copyright (c) Бежук, Козлов, Горшков, Минаева, Литвиненкова. All rights reserved.
// </copyright>

namespace TestDomain
{
    using Domain;

    /// <summary>
    /// Тесты для класса полка <see cref="Domain.Album"/>.
    /// </summary>
    public class AlbumTest
    {
   /// <summary>
   /// Тест на Tostring.
   /// </summary>
        [Test]
        public void ToString_ValidData_Succes()
        {
            var expected = "Тестовая полка";
            var album = new Album(expected);

            var actual = album.ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Тест на конструктор с параметром <see langword="null">.
        /// </summary>.
        [Test]
        public void Ctor_NullName_ExpectedException()
        {
            Assert.Throws<ArgumentNullException>(() => _ = new Album(null!));
        }

        /// <summary>
        ///  Тесты на метод Equals.
        /// </summary>
        /// <param name="name1"> Название первой полки</param>
        /// <param name="name2">Название второй полки</param>
        /// <param name="expected"> Результат метода</param>
        [TestCase("1", "1", true)]
        [TestCase("1", "2", false)]
        public void Equals_ValidData_Success(string name1, string name2, bool expected)
        {
            var album1 = new Album(name1);
            var album2 = new Album(name2);

            var actual = album1.Equals(album2);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}