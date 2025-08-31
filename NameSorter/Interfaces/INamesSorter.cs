using NameSorter.Models;
using System.Collections.Generic;

namespace NameSorter.Interfaces
{
    // Interface for sorting a collection of Name objects.
    public interface INamesSorter
    {
        // Sorts the given collection of names by last name, then by given names.
        IEnumerable<Name> Sort(IEnumerable<Name> names);
    }
}
