using System.Collections.Generic;
using System.Linq;

namespace Caldast.AlgoLife
{
    public class MyHashTable<K,V>
    {
        private int _capacity = 701;        
        private LinkedListNode[] _arr;
        private IEqualityComparer<K> _compare;
        public MyHashTable(int defaultCapacity)
        {
            _capacity = defaultCapacity > 0? defaultCapacity: _capacity;
            _arr = new LinkedListNode[_capacity];
            _compare = EqualityComparer<K>.Default;
        }
        public MyHashTable(): this(0)
        {          
        }
        public void Add(K key, V value)
        {
            int hashCode = GetHashCode(key);
            LinkedListNode node = _arr[hashCode];
            var newList = new LinkedListNode(key, value);
            if (node != null)
            {
                newList.Next = node;
                node.Previous = newList;
            }
            
            _arr[hashCode] = newList;
        }
        public void Remove(K key)
        {
            LinkedListNode node = GetNodeForKey(key);
            if (node != null)
            {
                if (node.Previous != null)
                {
                    node.Previous.Next = node.Next;
                }
                else
                {
                    // removing head
                    int hashCode = GetHashCode(key);
                    _arr[hashCode] = node.Next;
                }


                if (node.Next != null)
                {
                    node.Next.Previous = node.Previous;
                }
            }            
        }
        public V Search(K key)
        {
            LinkedListNode node = GetNodeForKey(key);
            return node == null ? default(V) : node.Value;
        }
        private LinkedListNode GetNodeForKey(K key)
        {
            int hashCode = GetHashCode(key);
            LinkedListNode node = _arr[hashCode];
            while (node != null)
            {
                if (_compare.Equals(node.Key, key))
                {
                    return node;
                }
               node = node.Next;
            }
            return null;
        }

        public int GetHashCode(K key)
        {
            return key.ToString().Length % _arr.Count();
        }
        class LinkedListNode 
        {
            public LinkedListNode Previous { get; set; }
            public LinkedListNode Next { get; set; }
            public K Key { get; set; }
            public V Value { get; set; }

            public LinkedListNode(K key, V value) {
                Key = key;
                Value = value;
            }
        }
    }
}
