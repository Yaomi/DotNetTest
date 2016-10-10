using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileMerger
{
    public class Program
    {
        private const string FileExtension = "txt";
        private const string InputDirectory = "../../../InputDirectory";
        private const string OutputDirectory = "../../../OutputDirectory";

        private static void Main(string[] args)
        {
            MergeFilesByFullName(InputDirectory, OutputDirectory);
        }

        private static void MergeFilesByFullName(string inputDirectory, string outputDirectory)
        {
            var fileNames = ReadFilesNames(inputDirectory);
            var fileGroups = GetFileGroups(fileNames);
            ConcatenateFiles(inputDirectory, outputDirectory, fileGroups);
        }

        private static Dictionary<string, ICollection<string>> GetFileGroups(IEnumerable<string> fileNames)
        {
            var fileGroups = new Dictionary<string, ICollection<string>>();
            foreach (var fileName in fileNames)
            {
                var idx = fileName.LastIndexOf('_');
                var firstPart = fileName.Substring(0, idx);
                var lastPart = fileName.Substring(idx + 1);

                ICollection<string> timestamps;
                if (!fileGroups.TryGetValue(firstPart, out timestamps))
                {
                    timestamps = new List<string>();
                    fileGroups.Add(firstPart, timestamps);
                }

                timestamps.Add(lastPart);
            }
            return fileGroups;
        }

        private static IEnumerable<string> ReadFilesNames(string inputDirectory)
        {
            var fileNames = Directory
                .GetFiles(inputDirectory, $"*.{FileExtension}")
                .Select(Path.GetFileName);
            return fileNames;
        }

        private static void ConcatenateFiles(string inputDirectory, string outputDirectory, IDictionary<string, ICollection<string>> fileGroups)
        {
            foreach (var fileGroup in fileGroups)
            {
                using (Stream output = File.OpenWrite($"{outputDirectory}/{fileGroup.Key}.{FileExtension}"))
                {
                    foreach (var inputFile in fileGroup.Value.Select(g => $"{inputDirectory}/{fileGroup.Key}_{g}"))
                    {
                        using (Stream input = File.OpenRead(inputFile))
                        {
                            input.CopyTo(output);
                        }
                    }
                }
            }
        }
    }
}