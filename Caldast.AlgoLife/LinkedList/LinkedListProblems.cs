using System.Collections.Generic;

namespace Caldast.AlgoLife.LinkedList
{
    public class LinkedListProblems
    {
        public class DownRightLinkedList
        {
            public DownRightLinkedList Down { get; set; }
            public DownRightLinkedList Right { get; set; }
            public int Value { get; set; }

            public DownRightLinkedList(int value)
            {
                Value = value;
            }
        }

        public DownRightLinkedList Flatten(DownRightLinkedList head)
        {
            if (head == null || head.Right == null)
                return head;

            head.Right = Flatten(head.Right);

            head = MergeList(head, head.Right);

            return head;
        }

        public DownRightLinkedList MergeList(DownRightLinkedList node1, DownRightLinkedList node2)
        {
            var n3 = new DownRightLinkedList(0);
            DownRightLinkedList n3Start = n3;

            while (node1 != null && node2 != null)
            {
                if (node1.Value < node2.Value)
                {
                    n3.Right = new DownRightLinkedList(node1.Value);
                    node1 = node1.Down;
                }
                else
                {
                    n3.Right = new DownRightLinkedList(node2.Value);
                    node2 = node2.Down;
                }
                n3 = n3.Right;
            }

            while (node1 != null)
            {
                n3.Right = new DownRightLinkedList(node1.Value);
                n3 = n3.Right;
                node1 = node1.Down;                
            }

            while (node2 != null)
            {
                n3.Right = new DownRightLinkedList(node2.Value);
                n3 = n3.Right;
                node2 = node2.Down;                
            }
            return n3Start.Right;
        }

        internal class Result {
            internal SinglyLinkedListNode<int> Node { get; set; }
            internal int Length { get; set; }
            public Result(SinglyLinkedListNode<int> n)
            {
                Node = n;
            }
        }
        public bool CheckPalindrome(SinglyLinkedListNode<int> head)
        {
            var res = new Result(head);
            return CheckPalindromeUtil(head, res, 0);
        }
        private bool CheckPalindromeUtil(SinglyLinkedListNode<int> head, Result res, int counter)
        {
            if (head == null)
                return true;

            res.Length++;
            if (!CheckPalindromeUtil(head.Next, res, counter + 1))
                return false;
            if (counter >= res.Length / 2)
            {
                if (res.Node.Value != head.Value)
                    return false;
                else
                    res.Node = res.Node.Next;
            }
            return true;
        }


        
        public SinglyLinkedListNode<int> EvenOddMerge(SinglyLinkedListNode<int> root)
        {
            if (root == null || root.Next == null)
                return null;
            SinglyLinkedListNode<int> even = root;
            SinglyLinkedListNode<int> odd = root.Next;
            SinglyLinkedListNode<int> oddFirst = odd;

            while (true)
            {
                even.Next = odd.Next;
                if (odd.Next == null)
                {
                    break;
                }
                even = odd.Next;

                odd.Next = even.Next;
                if (even.Next == null)
                {
                    break;
                }
                odd = even.Next;
            }
            even.Next = oddFirst;
            return root;
        }
        public void DeleteMiddle<T>(SinglyLinkedListNode<T> m, SinglyLinkedList<T> list)
        {
            SinglyLinkedListNode<T> temp = m.Next;
            m.Value = temp.Value;
            m.Next = temp.Next;
            temp.Next = null;
            temp = null;
        }

        public SinglyLinkedListNode<T> Partition<T>(SinglyLinkedListNode<T> root, T partition)
        {
           
            var tail = new SinglyLinkedListNode<T>(root.Value);
            var node = tail;

            while (root.Next != null)
            {
                root = root.Next;
                var n = new SinglyLinkedListNode<T>(root.Value);
                if (Comparer<T>.Default.Compare(root.Value, partition) < 0)
                {  
                    n.Next = node;
                    node = n;                    
                }
                else
                {
                    tail.Next = n;
                    tail = tail.Next;
                }                
            }

            return node;
        }

        public SinglyLinkedList<int> SumLists(SinglyLinkedList<int> list1, SinglyLinkedList<int> list2)
        {
            int len1 = list1.Count();
            int len2 = list2.Count();

            int diff = 0;
            SinglyLinkedList<int> longer = null;
            SinglyLinkedList<int> shorter = null;
            if (len1 > len2)
            {
                diff = len1 - len2;
                longer = list1;
                shorter = list2;
            }
            else
            {
                diff = len2 - len1;
                longer = list2;
                shorter = list1;
            }

            int i = 0;
            while (i < diff)
            {
                shorter.AddFirst(new SinglyLinkedListNode<int>(0));
                i++;
            }

            SinglyLinkedList<int> list3 = new SinglyLinkedList<int>();
            CarryHolder ch = SumListHelper(longer.Root, shorter.Root, list3);
            if (ch.Carry.Equals(1))
            {
                list3.AddFirst(new SinglyLinkedListNode<int>(ch.Carry));
            }
            return list3;
        }
        CarryHolder SumListHelper(SinglyLinkedListNode<int> longer, SinglyLinkedListNode<int> shorter, SinglyLinkedList<int> list3)
        {
            if (longer == null)
                return new CarryHolder(0);
            
            CarryHolder carryHolder = SumListHelper(longer.Next, shorter.Next, list3);
          
            int val = longer.Value + shorter.Value + carryHolder.Carry;  

            list3.AddFirst(new SinglyLinkedListNode<int>(val % 10));
            return new CarryHolder(val / 10);
        }
    }
    struct CarryHolder
    {
        public CarryHolder(int carry)
        {
            Carry = carry;
        }
        public int Carry { get; set; }
    }
}
