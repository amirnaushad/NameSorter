using NameSorter.Models;
using NameSorter.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace NameSorter.Services
{
    // Sorts a collection of Name objects
    public class NamesSorter : INamesSorter
    {
        // Sorts the names using the Name class's comparison logic.
        public IEnumerable<Name> Sort(IEnumerable<Name> names) =>
            names.OrderBy(n => n);
    }
}
