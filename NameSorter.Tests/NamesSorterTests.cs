using NUnit.Framework;
using NameSorter.Models;
using NameSorter.Services;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Legacy;

namespace NameSorter.Tests
{
    [TestFixture]
    public class NamesSorterTests
    {
        [Test]
        public void Sort_SortsByLastNameThenGivenNames()
        {
            var names = new List<Name>
            {
                new Name(new[] { "Janet" }, "Parsons"),
                new Name(new[] { "Vaughn" }, "Lewis"),
                new Name(new[] { "Adonis", "Julius" }, "Archer"),
                new Name(new[] { "Shelby", "Nathan" }, "Yoder"),
                new Name(new[] { "Marin" }, "Alvarez")
            };

            var sorter = new NamesSorter();
            var sorted = sorter.Sort(names).ToList();

            var expectedOrder = new[]
            {
                "Marin Alvarez",
                "Adonis Julius Archer",
                "Vaughn Lewis",
                "Janet Parsons",
                "Shelby Nathan Yoder"
            };

            CollectionAssert.AreEqual(expectedOrder, sorted.Select(n => n.FullName).ToArray());
        }
    }
}