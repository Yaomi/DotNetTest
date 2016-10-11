using System.IO;
using System.Threading;

namespace SubtitleWordCounter
{
    public class DataReader
    {
        private readonly string _filePath;
        private readonly TrieNode _rootNode;

        public DataReader(string filePath, ThreadLocal<TrieNode> rootNode)
        {
            _rootNode = rootNode.Value;
            _filePath = filePath;
        }

        public void ThreadRun()
        {
            using (var fileStream = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
            using (var streamReader = new StreamReader(fileStream))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var chunks = line.Split(null);
                    foreach (var chunk in chunks)
                    {
                        _rootNode.AddWord(chunk.Trim());
                    }
                }
            }
        }
    }
}