using NameSorter.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace NameSorter.Services
{
    public class FileService : IFileService
    {
        // Reads all lines from a file at the given path.
        public IEnumerable<string> ReadLines(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("File path cannot be null or whitespace.", nameof(path));

            try
            {
                return File.ReadLines(path);
            }
            catch (Exception ex) when (ex is IOException)
            {
                throw new IOException($"Failed to read from file '{path}': {ex.Message}", ex);
            }
        }

        // Writes all lines to a file at the given path, overwriting if it exists.
        public void WriteLines(string path, IEnumerable<string> lines)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("File path cannot be null or whitespace.", nameof(path));
            if (lines == null)
                throw new ArgumentNullException(nameof(lines));

            try
            {
                File.WriteAllLines(path, lines);
            }
            catch (Exception ex) when (ex is IOException)
            {
                throw new IOException($"Failed to write to file '{path}': {ex.Message}", ex);
            }
        }
    }
}
