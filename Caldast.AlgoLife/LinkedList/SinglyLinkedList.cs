using System;
using System.Runtime.Remoting.Messaging;

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

        public SinglyLinkedListNode<T> Root { get; private set; }

        public SinglyLinkedListNode<T> Last { get; private set; }

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

        public void Remove(T value)
        {
            if (Root == null || Last == null)
                return;

          
            if (Root.Value.Equals(value))
            {
                Root = Root.Next;

                if (Last.Value.Equals(value)) 
                {
                    Last = Last.Next;
                }

                return;
            }

            SinglyLinkedListNode<T> current = Root.Next;
            SinglyLinkedListNode<T> prev = Root;
           
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    break;
                }

                prev = current;
                current = current.Next;
            }

            if (current != null)
            {
                if (Last.Equals(current))
                {
                    Last = prev;
                }

                prev.Next = current.Next;
            }

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
