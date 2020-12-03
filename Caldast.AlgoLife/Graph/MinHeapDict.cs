using System;
using System.Collections.Generic;

namespace Caldast.AlgoLife.Graph
{
    internal class MinHeapDict<T>
    {

        private List<Node> _nodes = new List<Node>();
        private Dictionary<T, int> _dict = new Dictionary<T, int>();

        internal int HeapSize => _nodes.Count;

        internal int GetWeight(T key)
        {
            int pos = _dict[key];
            return _nodes[pos].Weight;
        }

        internal Node ExtractMinNode()
        {
            Node min = new Node(_nodes[0].Key,
                            _nodes[0].Weight);

            //_nodes[0];
            int last = _nodes.Count - 1;

            _nodes[0].Key = _nodes[last].Key;
            _nodes[0].Weight = _nodes[last].Weight;


            _nodes.RemoveAt(last);

            _dict.Remove(min.Key);

            if (_nodes.Count > 0)
            {
                _dict[_nodes[0].Key] = 0;
            }


            Heapify(0);

            return min;
        }

        internal T ExtractMin()
        {
            return ExtractMinNode().Key;

        }

        internal T Min()
        {
            return _nodes[0].Key;
        }
      

        internal void Heapify(int position)
        {
            while (position < HeapSize)
            {
                int left = Left(position);
                int right = Right(position);

                int smallest = position;
                if (left < HeapSize && _nodes[left].Weight < _nodes[position].Weight)
                {
                    smallest = left;
                }

                if (left < HeapSize && _nodes[left].Weight < _nodes[position].Weight)
                {
                    smallest = left;
                }
                if (right < HeapSize && _nodes[right].Weight < _nodes[smallest].Weight)
                {
                    smallest = right;
                }

                if (smallest != position)
                {
                    T smallestVertex = _nodes[smallest].Key;
                    T vertexToSwap = _nodes[position].Key;

                    Swap(_nodes[smallest], _nodes[position]);
                    UpdatePosition(smallestVertex, vertexToSwap, smallest, position);
                    position = smallest;
                }
                else
                {
                    break;
                }
            }

        }
        internal void Add(T key, int weight)
        {
            Node n = new Node(key, int.MaxValue);
            _nodes.Add(n);
            _dict.Add(key, _nodes.Count - 1);
            DecreaseKey(key, weight);
        }

        internal void DecreaseKey(T key, int weight)
        {
            if (!_dict.ContainsKey(key))
                throw new ArgumentException("Key not found");

            int position = _dict[key];

            if (weight > _nodes[position].Weight)
            {
                throw new Exception("key weight must be less than current");
            }

            _nodes[position].Weight = weight;
            int parentPosition = Parent(position);
            while (position > 0 && _nodes[position].Weight < _nodes[parentPosition].Weight)
            {
                T positionVertex = _nodes[position].Key;
                T parentVertex = _nodes[parentPosition].Key;

                Swap(_nodes[position], _nodes[parentPosition]);
                UpdatePosition(positionVertex, parentVertex, position, parentPosition);
                position = Parent(position);
                parentPosition = Parent(position);
            }
        }
        internal bool Contains(T currentKey)
        {
            return _dict.ContainsKey(currentKey);
        }
        private void UpdatePosition(T currentKey, T parentKey, int currentPosition, int parentPosition)
        {
            _dict[currentKey] = parentPosition;
            _dict[parentKey] = currentPosition;
        }

        private void Swap(Node node1, Node node2)
        {
            T key = node1.Key;
            int Weight = node1.Weight;

            node1.Key = node2.Key;
            node1.Weight = node2.Weight;

            node2.Key = key;
            node2.Weight = Weight;
        }



        internal int Parent(int i) => (i - 1) / 2;
        internal int Left(int i) => 2 * i + 1;
        internal int Right(int i) => 2 * i + 2;

        internal class Node
        {
            internal Node(T key, int weight)
            {
                Key = key;
                Weight = weight;
            }
            internal T Key { get; set; }
            internal int Weight { get; set; }
        }
    }

}
