using System;
using System.Linq;
using System.Text;

namespace Caldast.AlgoLife.Trie
{
    public class PatriciaTrie
    {
        private Node head = null;
        public PatriciaTrie()
        {
            head = new Node("",-1);
            head.Left = head;
            head.Right = head;           
        }

        class Node
        {
            internal int Bit { get; set; }
            internal Node Left { get; set; }
            internal Node Right { get; set; }
            internal string Item { get; set; }

            public Node(string item, int bit)
            {
                Item = item;
                Bit = bit;
            }
        }

        private string SearchR(Node h, string v, int w)
        {
            if (h.Bit <= w) return h.Item;

            if (Digit(v, h.Bit) == 0)
                return SearchR(h.Left, v, h.Bit);
            else return SearchR(h.Right, v, h.Bit);

        }

        private int Digit(string key, int index)
        {

            byte[] data = new UTF8Encoding().GetBytes(key);

            string str = string.Join("", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
            if (index < str.Length)
            {
                return str[index] - '0';
            }
            return -1;
        }

        public string STsearch(string v)

        {
            string t = SearchR(head.Left, v, -1);

            return t.Equals(head.Item) ? t : null;        
        }

        Node InsertR(Node h, string v, int w, Node p)
        {
            Node x; 
            if ((h.Bit >= w)||(h.Bit <= p.Bit))
            {
                x = new Node(v, w);
                x.Left = Digit(v, x.Bit) == 1 ? h: x;
                x.Right = Digit(v, x.Bit) == 1 ? x : h;
                return x;
            }
            if (Digit(v, h.Bit) == 0)
                h.Left = InsertR(h.Left, v, w, h);
            else
                h.Right= InsertR(h.Right, v, w, h);

            return h;
        }

        public void STInsert(string item)
        {
            string t = SearchR(head.Left,item,-1);
            if (t == item) return;

            int i = 0;
            while (t!= string.Empty && Digit(item, i) == Digit(t, i))
                i++;

            head.Left = InsertR(head.Left, item, i, head);
        }

    }
}
