using NameSorter.Models;

namespace NameSorter.Interfaces
{
    // Interface for parsing a line of text into a Name object.
    public interface INamesParser
    {
        // Parses a line of text and returns a Name object, or null if the line is invalid.
        Name? Parse(string line);
    }
}
