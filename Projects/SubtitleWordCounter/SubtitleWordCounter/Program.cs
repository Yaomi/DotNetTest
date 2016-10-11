using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace SubtitleWordCounter
{
    internal class Program
    {
        private const string InputDirectory = "../../../Subtitles/";
        private const string SearchWord = "this";

        public static void Main(string[] args)
        {
            Console.WriteLine("Counting words...");

            var startAt = DateTime.Now;

            var resultNode = ProcessFiles(InputDirectory);

            var stopAt = DateTime.Now;

            Console.WriteLine("Input data processed in {0} secs", new TimeSpan(stopAt.Ticks - startAt.Ticks).TotalSeconds);
            Console.WriteLine();

            var count = resultNode.Value.GetCount(SearchWord);
            Console.WriteLine("{0} - {1} times", SearchWord, count);

            var distinctWordCount = 0;
            var totalWordCount = 0;
            resultNode.Value.GetStatistics(ref distinctWordCount, ref totalWordCount);

            resultNode.Dispose();

            Console.WriteLine();
            Console.WriteLine("{0} words counted", totalWordCount);
            Console.WriteLine("{0} distinct words found", distinctWordCount);
            Console.WriteLine();
            Console.WriteLine("done.");
            Console.ReadLine();
        }

        private static ThreadLocal<TrieNode> ProcessFiles(string inputDirectory)
        {
            var readers = new Dictionary<DataReader, Thread>();
            var roots = InitThreadLocals(readers, inputDirectory);

            foreach (var t in readers.Values)
            {
                t.Join();
            }

            foreach (var root in roots.Skip(1))
            {
                roots[0].Value.CombineNode(root.Value);
                root.Dispose();
            }
            return roots[0];
        }

        private static List<ThreadLocal<TrieNode>> InitThreadLocals(IDictionary<DataReader, Thread> readers, string inputDirectory)
        {
            List<ThreadLocal<TrieNode>> roots;
            var files = ReadFilesNames(inputDirectory);
            if (!files.Any())
            {
                roots = new List<ThreadLocal<TrieNode>>(1);
            }
            else
            {
                roots = new List<ThreadLocal<TrieNode>>(files.Count());

                foreach (var path in files)
                {
                    var root = new ThreadLocal<TrieNode>(() => new TrieNode(null, '?'));

                    roots.Add(root);

                    var newReader = new DataReader(path, root);
                    var newThread = new Thread(newReader.ThreadRun);
                    readers.Add(newReader, newThread);
                    newThread.Start();
                }
            }
            return roots;
        }

        private static ICollection<string> ReadFilesNames(string inputDirectory)
        {
            var fileNames = Directory
                .GetFiles(inputDirectory, "*.srt")
                .Select(Path.GetFullPath)
                .ToList();
            return fileNames;
        }
    }
}