using System;
using System.Collections.Generic;

namespace Caldast.AlgoLife.UnionFind
{
    /// <summary>
    /// Uses Union by Rank and Path Compression heuristics.
    /// For m disjoint-set operations, out of which n are MakeSet operations,
    /// Time complexity will be O(mα(n))
    /// For all practical purposes α(n) &lt;=4.
    /// Hence O(m) 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DisjointSet<T> where T: IComparable, IComparable<T>
    { 
        public class Node
        {
            public Node(T value)
            {
                Value = value;
            }
            public T Value { get; private set; }
            public int Rank { get; set; }
            public Node Parent { get; set; }
        }
        private Dictionary<T, Node> _dict = new Dictionary<T, Node>();

        private void Link(Node x, Node y)
        {
            if (x.Rank > y.Rank)
            {
                y.Parent = x;
            }
            else
            {
                x.Parent = y;
                if (x.Rank == y.Rank)
                {
                    y.Rank = y.Rank + 1;
                }
            }
        }

    
        public void MakeSet(T value)
        {
            var node = new Node(value)
            {
                Rank = 0
            };
            node.Parent = node;

            _dict.Add(value,node);
        }

        public void Union(T x, T y)
        {

            Link(FindSet(_dict[x]), FindSet(_dict[y]));
        }
        public T FindSet(T x)
        {
            return FindSet(_dict[x]).Value;
        }

        public Node FindSet(Node x)
        {
            if (x.Parent == x)
                return x;
            x.Parent = FindSet(x.Parent);
            return x.Parent;
        }
    }
}
