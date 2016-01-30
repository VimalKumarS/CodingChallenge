using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;
namespace HackerRank
{
    //http://stackoverflow.com/questions/12190326/parsing-one-terabyte-of-text-and-efficiently-counting-the-number-of-occurrences
   public class TrieNode
    {
        private char m_char;
        public int m_word_count;
        private TrieNode m_parent = null;
        private ConcurrentDictionary<char, TrieNode> m_children = null;

        public TrieNode(TrieNode parent, char c)
        {
            m_char = c;
            m_word_count = 0;
            m_parent = parent;
            m_children = new ConcurrentDictionary<char, TrieNode>();
        }

        public void AddWord(string word, int index=0)
        {
            if(index<word.Length)
            {
                char key = word[index];
                if (char.IsLetter(key))
                {
                    if (!m_children.ContainsKey(key))
                    {
                        m_children.TryAdd(key, new TrieNode(this, key));
                    }
                    m_children[key].AddWord(word, index + 1);
                }
                else
                {
                    AddWord(word, index + 1);
                }
            }
            else
            {
                if(m_parent != null)
                {
                    lock(this)
                    {
                        m_word_count++;
                    }
                }
            }
        }

        public int GetCount(string word, int index = 0)
        {
            if (index < word.Length)
            {
                char key = word[index];
                if (!m_children.ContainsKey(key))
                {
                    return -1;
                }
                return m_children[key].GetCount(word, index + 1);
            }
            else
            {
                return m_word_count;
            }
        }

       public void GetAllWordCount(TrieNode ParenNode,ref Dictionary<String,int> lst,string word)
        {
           foreach(KeyValuePair<char,TrieNode> childnode in ParenNode.m_children)
           {
              if(childnode.Value.m_children.Count == 0)
              {
                  lst.Add(word + childnode.Key.ToString(), childnode.Value.m_word_count);
              }
              else
              {
                  GetAllWordCount(childnode.Value, ref lst, word+childnode.Key.ToString());
              }
           }
        }
    }
}
