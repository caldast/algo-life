using System;

namespace Caldast.AlgoLife.LinkedList
{
    public class XorLinkedList
    {
        public XorLinkedListNode Root { get; set; }

        public void AddFirst(int value)
        {
            throw new NotImplementedException();
        }
        public void Iterate()
        {
            throw new NotImplementedException();
        }
    }

    public class XorLinkedListNode
    {
        public XorLinkedListNode(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
        public XorLinkedListNode NextPreviousRef { get; set; }
    }
}
