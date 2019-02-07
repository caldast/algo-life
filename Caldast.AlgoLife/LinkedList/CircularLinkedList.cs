using System;

namespace Caldast.AlgoLife.LinkedList
{
    class CircularLinkedList
    {
        public CircularLinkedListNode Head { get; private set; }

        public class CircularLinkedListNode 
        {             
            public CircularLinkedListNode Next;
            public int Value;
            public CircularLinkedListNode(int value)
            {
                Value = value;
            }
        }
        public void AddFirst(int value)
        {
            var n = new CircularLinkedListNode(value);
            if (Head == null)
            {
                Head = n;
                Head.Next = n;
            }
            else
            {
                CircularLinkedListNode current = Head;
                while (current.Next != Head)
                {
                    current = current.Next;
                }
                if (current.Next == Head)
                {
                    current.Next = n;
                    n.Next = Head;
                    Head = n;
                }

            }
        }

        public void DeleteAllOdds()
        {
            if (Head == null)
            {
                throw new Exception("Linked list is empty");
            }

            CircularLinkedListNode current = Head.Next;
            CircularLinkedListNode prev = Head;
            int pos = 2;
            while (current != Head)
            {
                if (pos % 2 == 1)
                {
                    prev.Next = current.Next;
                    current.Next = null;
                    current = prev.Next;
                }
                else
                {
                    prev = current;
                    current = current.Next;
                }
                pos++;
            }
            if (current == Head)
            {
                prev.Next = current.Next;
                current.Next = null;
                Head = prev.Next;

            }
        }
    }
}
