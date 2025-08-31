using System;
using System.Collections.Generic;
using System.Linq;

namespace NameSorter.Models
{
    // Represents a person's name, including given names and last name.
    public class Name : IComparable<Name>
    {
        // The given names (first, middle, etc.).
        public string[] GivenNames { get; }

        // The last name (surname).
        public string LastName { get; }

        // The full name, combining given names and last name.
        public string FullName => string.Join(" ", GivenNames.Concat(new[] { LastName }));

        // Creates a new Name instance from given names and last name.
        public Name(IEnumerable<string> givenNames, string lastName)
        {
            GivenNames = givenNames.ToArray();
            LastName = lastName;
        }

        // Compares this name to another for sorting: by last name, then given names.
        public int CompareTo(Name? other)
        {
            if (other == null) return 1;
            int lastNameComparison = string.Compare(LastName, other.LastName, StringComparison.OrdinalIgnoreCase);
            if (lastNameComparison != 0) return lastNameComparison;

            for (int i = 0; i < Math.Min(GivenNames.Length, other.GivenNames.Length); i++)
            {
                int givenNameComparison = string.Compare(GivenNames[i], other.GivenNames[i], StringComparison.OrdinalIgnoreCase);
                if (givenNameComparison != 0) return givenNameComparison;
            }
            return GivenNames.Length.CompareTo(other.GivenNames.Length);
        }
    }
}
