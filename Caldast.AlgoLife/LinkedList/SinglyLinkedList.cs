using System;

namespace Caldast.AlgoLife.LinkedList
{
    public class SinglyLinkedList<T>
    {
        public SinglyLinkedList()
        {
        }
            public SinglyLinkedList(SinglyLinkedListNode<T> root)
        {
            Root = root;
        }

        public SinglyLinkedListNode<T> Root { get; set; }

        public SinglyLinkedListNode<T> Last { get; set; }

        public void AddFirst(SinglyLinkedListNode<T> n)
        {
            if (Root == null)
            {
                Root = n;
                Last = n;
                return;
            }
            n.Next = Root;
            Root = n;
        }

        public void AddLast(SinglyLinkedListNode<T> n)
        {
            if (Last == null)
            {
                Root = n;
                Last = n;
                return;
            }
            Last.Next = n;
            Last = n;
        }

        public int Count()
        {
            int len = 0;
            SinglyLinkedListNode<T> current = Root;
            while (current != null)
            {
                len++;
                current = current.Next;
            }
            return len;
        }

        public void Print()
        {
            SinglyLinkedListNode<T> current = Root;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }
    }
    public class SinglyLinkedListNode<T>
    {
        public SinglyLinkedListNode(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
        public SinglyLinkedListNode<T> Next;

        public void Print()
        {
            SinglyLinkedListNode<T> current = this;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }

        }      

    }
}
