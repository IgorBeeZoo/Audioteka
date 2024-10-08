// <copyright file="ShelfTest.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace TestDomain
{
    using Domain;
    /// <summary>
    /// Тесты для класса полка <see cref="Domain.Shelf"/>.
    /// </summary>
    public class ShelfTest
    {
   /// <summary>
   /// Тест на Tostring.
   /// </summary>
        [Test]
        public void ToString_ValidData_Succes()
        {
            var expected = "Тестовая полка";
            var shelf = new Shelf(expected);

            var actual = shelf.ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Тест на конструктор с параметром <see langword="null"> 
        /// </summary>
        [Test]
        public void Ctor_NullName_ExpectedException()
        {
            Assert.Throws<ArgumentNullException>(() => _ = new Shelf(null!));
        }

        /// <summary>
        ///  Тесты на метод Equals
        /// </summary>
        /// <param name="name1"> Название первой полки</param>
        /// <param name="name2">Название второй полки</param>
        /// <param name="expected"> Результат метода</param>
        [TestCase("1", "1", true)]
        [TestCase("1", "2", false)]
        public void Equals_ValidData_Success(string name1, string name2, bool expected)
        {
            var shelf1 = new Shelf(name1);
            var shelf2 = new Shelf(name2);

            var actual = shelf1.Equals(shelf2);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}