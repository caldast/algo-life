using System;
using System.Collections.Generic;
using System.Linq;

namespace Caldast.AlgoLife.Graph.Prim_sAlgorithm
{
    internal class PrimsMST
    {

        internal PrimsMST() { }

        public List<Graph.Edge> FindMST(Graph graph)
        {
            var minHeapDict = new MinHeapDict();
            var VE = new Dictionary<Graph.Vertex, Graph.Edge>();
            var result = new List<Graph.Edge>();

            LinkedList<Graph.Vertex> vertices = graph.GetVertices();
            foreach (Graph.Vertex v in vertices)
            {
                minHeapDict.Add(v, int.MaxValue);
            }

            Graph.Vertex startVertex = vertices.First();
            minHeapDict.DecreaseKey(startVertex, 0);

            while (minHeapDict.HeapSize != 0)
            {
                if (VE.Count == 5)
                {
                }
                Graph.Vertex v = minHeapDict.ExtractMin();
                if (VE.ContainsKey(v) && v != startVertex)
                {
                    result.Add(VE[v]);
                }
                foreach (Graph.Edge e in v.GetAdjanceEdges())
                {
                    if (minHeapDict.Contains(e.Destination)
                        && e.Weight < minHeapDict.GetWeight(e.Destination))
                    {
                       
                        minHeapDict.DecreaseKey(e.Destination, e.Weight);
                        
                        if (VE.ContainsKey(e.Destination))
                        {
                            VE[e.Destination] = e;
                        }
                        else
                        {
                            VE.Add(e.Destination, e);
                        }
                    }
                }
            }
            return result;

        }
        internal class MinHeapDict
        {

            private List<Node> _nodes = new List<Node>();
            private Dictionary<Graph.Vertex, int> _dict = new Dictionary<Graph.Vertex, int>();

            internal int HeapSize => _dict.Count;

            internal int GetWeight(Graph.Vertex key)
            {
                int pos = _dict[key];
                return _nodes[pos].Weight;
            }
            internal Graph.Vertex ExtractMin()
            {
                Graph.Vertex min = _nodes[0].Key;
                int last = _nodes.Count - 1;

                _nodes[0].Key = _nodes[last].Key;
                _nodes[0].Weight = _nodes[last].Weight;

               
                _nodes.RemoveAt(last);

                _dict.Remove(min);
                //_dict.Remove(_nodes[0].Key);
                //_dict.Add(_nodes[0].Key, 0);

                if (_nodes.Count > 0)
                {
                    _dict[_nodes[0].Key] = 0;
                }


                Heapify(0);
               
                return min;

            }
            internal Graph.Vertex Min()
            {
               return _dict.ElementAt(0).Key;
            }
            internal void Heapify(int position)
            {
                int left = Left(position);
                int right = Right(position);
                int smallest = position;

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
                    Graph.Vertex smallestVertex = _nodes[smallest].Key;
                    Graph.Vertex vertexToSwap = _nodes[position].Key;

                    Swap(_nodes[smallest], _nodes[position]);
                    UpdatePosition(smallestVertex, vertexToSwap, smallest, position);
                    Heapify(smallest);
                }

            }
            internal void Add(Graph.Vertex key, int weight)
            {
                Node n = new Node(key, int.MaxValue);
                _nodes.Add(n);
                _dict.Add(key, _nodes.Count() - 1);
                DecreaseKey(key, weight);
            }

            internal void DecreaseKey(Graph.Vertex key, int weight)
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
                    Graph.Vertex positionVertex = _nodes[position].Key;
                    Graph.Vertex parentVertex = _nodes[parentPosition].Key;

                    Swap(_nodes[position], _nodes[parentPosition]);
                    UpdatePosition(positionVertex, parentVertex, position, parentPosition);
                    position = Parent(position);
                    parentPosition = Parent(position);
                }
            }
            internal bool Contains(Graph.Vertex currentKey)
            {
                return _dict.ContainsKey(currentKey);
            }
            private void UpdatePosition(Graph.Vertex currentKey, Graph.Vertex parentKey, int currentPosition, int parentPosition)
            {
                _dict[currentKey] = parentPosition;
                _dict[parentKey] = currentPosition;


                //_dict.Remove(currentKey);
                //_dict.Remove(parentKey);
                //_dict.Add(currentKey, currentPosition);
                //_dict.Add(parentKey, parentPosition);
            }

            private void Swap(Node node1, Node node2)
            {
                Graph.Vertex key = node1.Key;
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
                internal Node(Graph.Vertex key, int weight)
                {
                    Key = key;
                    Weight = weight;
                }
                internal Graph.Vertex Key { get; set; }
                internal int Weight { get; set; }
            }
        }

        internal class Graph
        {
            private Dictionary<int, Vertex> _dict = new Dictionary<int, Vertex>();
            private LinkedList<Edge> edges = new LinkedList<Edge>();
            public bool IsDirected { get; set; }
            internal Graph(bool isDirected)
            {
                IsDirected = isDirected;
            }

            internal void AddVertex(int v)
            {
                if (!_dict.ContainsKey(v))
                {

                    _dict.Add(v, new Vertex(v));
                }
            }
            internal void AddEdge(int v1, int v2, int weight)
            {
                Vertex vertex1 = null;
                Vertex vertex2 = null;
                if (!_dict.ContainsKey(v1))
                {
                    vertex1 = new Vertex(v1);
                    _dict.Add(v1, vertex1);
                }
                else
                {
                    vertex1 = _dict[v1];
                }

                if (!_dict.ContainsKey(v2))
                {
                    vertex2 = new Vertex(v2);
                    _dict.Add(v2, vertex2);
                }
                else
                {
                    vertex2 = _dict[v2];
                }

                Edge e = new Edge(vertex1, vertex2, IsDirected, weight);
                edges.AddLast(e);
                vertex1.AddAdjacentEdge(e);
                if (!IsDirected)
                {
                    e = new Edge(vertex2, vertex1, IsDirected, weight);
                    vertex2.AddAdjacentEdge(e);
                }
            }

            internal LinkedList<Edge> GetEdges()
            {
                return edges;
            }

            internal LinkedList<Vertex> GetVertices()
            {
                LinkedList<Vertex> vertices = new LinkedList<Vertex>();
                foreach (var v in _dict.Values)
                {
                    vertices.AddLast(v);
                }
                return vertices;
            }

            internal bool Contains(int v)
            {
                return _dict.ContainsKey(v);
            }

            internal class Vertex
            {
                LinkedList<Edge> edges = new LinkedList<Edge>();
                internal int Value { get; set; }

                internal Vertex(int value)
                {
                    this.Value = value;
                }

                internal void AddAdjacentEdge(Edge e)
                {
                    edges.AddLast(e);
                }

                internal LinkedList<Edge> GetAdjanceEdges()
                {
                    return edges;
                }

                public override bool Equals(object obj)
                {
                   Vertex vertex = obj as Vertex;

                   if (vertex == null)
                        return false;
                    return Value == vertex.Value;
                }

                public override int GetHashCode()
                {
                    return base.GetHashCode();
                }


            }
            internal class Edge
            {
                internal Vertex Source { get; set; }
                internal Vertex Destination { get; set; }

                internal int Weight { get; set; }
                internal bool IsDirected { get; set; }
                internal Edge(Vertex source, Vertex destination)
                {
                    Source = source;
                    Destination = destination;
                }
                internal Edge(Vertex source, Vertex destination, bool isDirected, int weight)
                {
                    Source = source;
                    Destination = destination;
                    IsDirected = isDirected;
                    Weight = weight;
                }
            }
        }
    }
}
