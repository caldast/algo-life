namespace Caldast.AlgoLife.Trie
{
    public class WordDictionary
    {
        private TNode _root;
        /** Initialize your data structure here. */
        public WordDictionary()
        {
            _root = new TNode();
        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {
            TNode current = _root;

            foreach (char c in word)
            {
                int asc =  c - 'a';

                if (asc < 0 || asc > 26) return;

                if (current.Children[asc] == null)
                    current.Children[asc] = new TNode();
                current = current.Children[asc];
            }
            current.IsEndOfWord = true;
        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            return SearchUtil(word, _root, 0);
        }

        private bool SearchUtil(string word, TNode node, int index)
        {
            if (word.Length == index)
            {
                return node.IsEndOfWord;
            }

            char c = word[index];
            int asc = word[index] - 'a';

           
            if (c != '.' && node.Children[asc] == null)
                return false;

            if (c == '.')
            {
                foreach (var item in node.Children)
                {
                    if(item!= null)
                    {
                        if (SearchUtil(word, item, index + 1))
                        {
                            return true;
                        }
                    }
                }
            }
            else
            {
                return SearchUtil(word, node.Children[asc], index + 1);
            }
            return false;
        }

        class TNode
        {
            internal TNode[] Children { get; }
            internal bool IsEndOfWord { get; set; }

            internal TNode()
            {
                Children = new TNode[26];

            }

        }

    }
}
