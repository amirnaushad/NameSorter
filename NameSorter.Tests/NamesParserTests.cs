using NameSorter.Services;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace NameSorter.Tests
{
    [TestFixture]
    public class NamesParserTests
    {
        private NamesParser _parser;

        [SetUp]
        public void SetUp()
        {
            _parser = new NamesParser();
        }

        [Test]
        public void Parse_ValidLine_ReturnsName()
        {
            var name = _parser.Parse("Adonis Julius Archer");
            Assert.That(name, Is.Not.Null);
            Assert.That(name!.LastName, Is.EqualTo("Archer"));
            CollectionAssert.AreEqual(new[] { "Adonis", "Julius" }, name.GivenNames);
        }

        [Test]
        public void Parse_SingleGivenName_ReturnsName()
        {
            var name = _parser.Parse("Janet Parsons");
            Assert.That(name, Is.Not.Null);
            Assert.That(name!.LastName, Is.EqualTo("Parsons"));
            CollectionAssert.AreEqual(new[] { "Janet" }, name.GivenNames);
        }

        [Test]
        public void Parse_ThreeGivenNames_ReturnsName()
        {
            var name = _parser.Parse("Hunter Uriah Mathew Clarke");
            Assert.That(name, Is.Not.Null);
            Assert.That(name!.LastName, Is.EqualTo("Clarke"));
            CollectionAssert.AreEqual(new[] { "Hunter", "Uriah", "Mathew" }, name.GivenNames);
        }

        [Test]
        public void Parse_EmptyLine_ReturnsNull()
        {
            var name = _parser.Parse("");
            Assert.That(name, Is.Null);
        }

        [Test]
        public void Parse_WhitespaceLine_ReturnsNull()
        {
            var name = _parser.Parse("   ");
            Assert.That(name, Is.Null);
        }

        [Test]
        public void Parse_OnlyLastName_ReturnsNull()
        {
            var name = _parser.Parse("Smith");
            Assert.That(name, Is.Null); 
        }

        [Test]
        public void Parse_MultipleSpacesBetweenNames_ParsesCorrectly()
        {
            var name = _parser.Parse("  Beau   Tristan   Bentley  ");
            Assert.That(name, Is.Not.Null);
            Assert.That(name!.LastName, Is.EqualTo("Bentley"));
            CollectionAssert.AreEqual(new[] { "Beau", "Tristan" }, name.GivenNames);
        }
    }
}