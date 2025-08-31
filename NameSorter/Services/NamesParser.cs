using NameSorter.Interfaces;
using NameSorter.Models;
using System;
using System.Linq;

namespace NameSorter.Services
{
    // Parses a line of text into a Name object.
    public class NamesParser : INamesParser
    {
        // Parses a line into a Name, or returns null if invalid.
        public Name? Parse(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) 
                return null;

            // Split the line into parts, removing extra spaces.
            var parts = line.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            // Must have at least one given name and a last name.
            if (parts.Length < 2)
                return null; 

            var lastName = parts[parts.Length - 1]; // Last part is the last name.
            var givenNames = new ArraySegment<string>(parts, 0, parts.Length - 1); // All but last are given names.

            return new Name(givenNames, lastName);

        }
    }
}
