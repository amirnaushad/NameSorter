using NUnit.Framework;
using NameSorter.Models;
using NUnit.Framework.Legacy;

namespace NameSorter.Tests
{
    [TestFixture]
    public class NameTests
    {
        [Test]
        public void Constructor_SetsPropertiesCorrectly()
        {
            var givenNames = new[] { "Adonis", "Julius" };
            var lastName = "Archer";
            var name = new Name(givenNames, lastName);

            CollectionAssert.AreEqual(givenNames, name.GivenNames);
            Assert.That(name.LastName, Is.EqualTo(lastName));
        }

        [Test]
        public void FullName_ReturnsCorrectFormat()
        {
            var name = new Name(new[] { "Adonis", "Julius" }, "Archer");
            Assert.That(name.FullName, Is.EqualTo("Adonis Julius Archer"));
        }
    }
}