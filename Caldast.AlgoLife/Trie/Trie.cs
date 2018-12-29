using System;
using System.Collections.Generic;

namespace Caldast.AlgoLife.Trie
{
    public class Trie
    {
        private TrieNode _root = new TrieNode();
        public Trie() { }

        public void Insert(string word)
        {
            if (word == null || word.Length == 0)
            {
                throw new ArgumentException("input cannot be null or empty");
            }

            TrieNode current = _root;
            for (int i = 0; i < word.Length; i++)
            {
                char ch = word[i];               

                if (!current.Children.ContainsKey(ch))
                {                    
                    current.Children.Add(ch, new TrieNode());
                }

                current = current.Children[ch];                
            }
            current.IsEndOfWord = true;

        }
        public bool RecursiveSearchWord(string word)
        {
            return RecursiveSearchUtil(word, _root, 0);
        }

        private bool RecursiveSearchUtil(string word, TrieNode node, int index)
        {
            if (index == word.Length)
            {
                return node.IsEndOfWord;
            }

            char ch = word[index];
            if (!node.Children.ContainsKey(ch))
                return false;

            node = node.Children[ch];
            return RecursiveSearchUtil(word, node, index + 1);

        }
        public bool SearchWord(string word)
        {
            TrieNode current = _root;

            for (int i = 0; i < word.Length; i++)
            {
                char ch = word[i];

                if (!current.Children.ContainsKey(ch))
                    return false;

                current = current.Children[ch];
            }
            return current.IsEndOfWord;
        }
     
        public void Delete(string word)
        {
            DeleteUtil(word, _root, 0);
        }
        private bool DeleteUtil(string word, TrieNode node, int index)
        {
            if (index < 0 || index > word.Length)
            {
                return false;
            }            

            if (index == word.Length)
            {
                if (!node.IsEndOfWord)
                    return false;

                node.IsEndOfWord = false;
                return node.Children.Count == 0;
            }

            char ch = word[index];

            if (!node.Children.ContainsKey(ch))
                return false;

            TrieNode currentNode = node.Children[ch];
            bool canDelete = DeleteUtil(word, currentNode, index+1);

            if (canDelete)
            {                
                if (currentNode.Children.Count == 0)
                {
                    node.Children.Remove(ch);
                }
                return node.Children.Count == 0;
            }
            return false;

        }
    }
    public class TrieNode
    {
        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
            IsEndOfWord = false;
        }
        public Dictionary<char,TrieNode> Children { get; set; }
        public bool IsEndOfWord { get; set; }       

    }
}
