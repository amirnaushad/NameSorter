using System.Collections.Generic;

namespace NameSorter.Interfaces
{
    // Interface for file operations
    public interface IFileService
    {
        // Reads all lines from the specified file path.
        IEnumerable<string> ReadLines(string path);

        // Writes the provided lines to the specified file path, overwriting if it exists.
        void WriteLines(string path, IEnumerable<string> lines);
    }
}
