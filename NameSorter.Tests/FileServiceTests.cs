using NUnit.Framework;
using NameSorter.Services;
using System.IO;
using System.Linq;
using NUnit.Framework.Legacy;

namespace NameSorter.Tests
{
    [TestFixture]
    public class FileServiceTests
    {
        private FileService _fileService;
        private string _tempFile;

        [SetUp]
        public void SetUp()
        {
            _fileService = new FileService();
            _tempFile = Path.GetTempFileName();
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(_tempFile))
                File.Delete(_tempFile);
        }

        [Test]
        public void WriteLines_And_ReadLines_WorkCorrectly()
        {
            var linesToWrite = new[] { "Janet Parsons", "Vaughn Lewis", "Adonis Julius Archer" };
            _fileService.WriteLines(_tempFile, linesToWrite);

            var linesRead = _fileService.ReadLines(_tempFile).ToArray();
            CollectionAssert.AreEqual(linesToWrite, linesRead);
        }
    }
}