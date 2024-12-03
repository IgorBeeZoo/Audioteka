// <copyright file="AuthorTest.cs" company="Бежук, Козлов, Горшков, Минаева, Литвиненкова">
// Copyright (c) Бежук, Козлов, Горшков, Минаева, Литвиненкова. All rights reserved.
// </copyright>

namespace TestDomain
{
    using Domain;

    internal class AuthorTest
    {
        [Test]
        public void Equalas_DifferentAuthors_False()
        {
            var author1 = new Album("Шклярский", "Эдмунд", "Мечиславович");
            var author2 = new Album("Кипелов", "Валерий", "Александрович");
            Assert.That(author1, Is.Not.EqualTo(author2));
        }

        [TestCase(null, "")]
        [TestCase("", null)]
        public void Ctor_WrongData_ExpectedException(string? familyName, string? firstName)
        {
            Assert.Throws<ArgumentNullException>(
                () => _ = new Album(familyName!, firstName!));
        }

        [TestCaseSource(nameof(ValidNullDates))]
        public void Equals_SimilarAuthorsDifferentDates_False(
            DateOnly? dateBirth1,
            DateOnly? dateBirth2,
            DateOnly? dateDeath1,
            DateOnly? dateDeath2)
        {
            // Arrange
            var author1 = new Album("Шклярский", "Эдмунд", "Мечиславович", dateBirth1, dateDeath1);
            var author2 = new Album("Магомаев", "Муслим", "Магометович", dateBirth2, dateDeath2);

            // Act & Assert
            Assert.That(author1, Is.Not.EqualTo(author2));
        }

        private static IEnumerable<TestCaseData> ValidDateData()
        {
            yield return new TestCaseData(new DateOnly(1955, 09, 26), null);
            yield return new TestCaseData(null, new DateOnly(2008, 10, 25));
            yield return new TestCaseData(null, null);
        }

        private static IEnumerable<TestCaseData> ValidNullDates()
        {
            yield return new TestCaseData(null, null, null, null);
        }
    }
}
