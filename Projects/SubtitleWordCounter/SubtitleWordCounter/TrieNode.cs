using System;
using System.Collections.Generic;
using System.Text;

namespace SubtitleWordCounter
{
    public class TrieNode
    {
        private readonly char _char;
        private readonly Dictionary<char, TrieNode> _childrenNodes;
        private readonly TrieNode _parentNode;
        public int WordCount;

        public TrieNode(TrieNode parentNode, char c)
        {
            WordCount = 0;

            _char = c;
            _parentNode = parentNode;
            _childrenNodes = new Dictionary<char, TrieNode>();
        }

        public void CombineNode(TrieNode from)
        {
            foreach (var fromChild in from._childrenNodes)
            {
                var keyChar = fromChild.Key;
                if (!_childrenNodes.ContainsKey(keyChar))
                {
                    _childrenNodes.Add(keyChar, new TrieNode(this, keyChar));
                }
                _childrenNodes[keyChar].WordCount += fromChild.Value.WordCount;
                _childrenNodes[keyChar].CombineNode(fromChild.Value);
            }
        }

        public void AddWord(string word, int index = 0)
        {
            while (true)
            {
                if (index < word.Length)
                {
                    var key = word[index];
                    if (char.IsLetter(key))
                    {
                        if (!_childrenNodes.ContainsKey(key))
                        {
                            _childrenNodes.Add(key, new TrieNode(this, key));
                        }
                        _childrenNodes[key].AddWord(word, index + 1);
                    }
                    else
                    {
                        index = index + 1;
                        continue;
                    }
                }
                else
                {
                    if (_parentNode != null)
                    {
                        WordCount++;
                    }
                }
                break;
            }
        }

        public int GetCount(string word, int index = 0)
        {
            if (index < word.Length)
            {
                var key = word[index];
                if (!_childrenNodes.ContainsKey(key))
                {
                    return -1;
                }
                return _childrenNodes[key].GetCount(word, index + 1);
            }
            return WordCount;
        }

        public void GetStatistics(ref int distinctWordCount, ref int totalWordCount)
        {
            if (WordCount > 0)
            {
                distinctWordCount++;
                totalWordCount += WordCount;
            }

            foreach (var key in _childrenNodes.Keys)
            {
                _childrenNodes[key].GetStatistics(ref distinctWordCount, ref totalWordCount);
            }
        }

        public override string ToString()
        {
            return BuildString(new StringBuilder()).ToString();
        }

        private StringBuilder BuildString(StringBuilder builder)
        {
            return _parentNode?.BuildString(builder).Append(_char) ?? builder;
        }
    }
}