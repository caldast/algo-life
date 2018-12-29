using System;
using System.Collections.Generic;
using System.Linq;

namespace Caldast.AlgoLife.Graph
{
    public sealed class Graph<IVertex>
    {
        private Dictionary<IVertex, LinkedList<IVertex>> _hashTable;

        public Graph()
        {
            _hashTable = new Dictionary<IVertex, LinkedList<IVertex>>();
        }

        public void AddVertex(IVertex vertex)
        {
            if (!ContainsVertex(vertex))
                _hashTable.Add(vertex,new LinkedList<IVertex>());
            else
                throw new InvalidOperationException("Cannot contain duplicate vertex");
        }

        public LinkedList<IVertex> GetEdges(IVertex vertex)
        {
            if (ContainsVertex(vertex))
                return _hashTable[vertex];
            else
                throw new InvalidOperationException("Cannot contain duplicate vertex");
        }

        public LinkedList<IVertex> GetVertices()
        {
            var vertices = new LinkedList<IVertex>();

            foreach (IVertex t in _hashTable.Keys)
                vertices.AddLast(t);

            return vertices;

        }

        public void AddEdge(IVertex source, IVertex destination)
        {
            if(ContainsVertex(source))
                _hashTable[source].AddLast(destination);
            else
                throw new InvalidOperationException("Vertices not found");                     
        }

        public bool ContainsVertex(IVertex source)
        {
            return _hashTable.ContainsKey(source);
        }

        public Graph<IVertex> Transpose()
        {
            var g = new Graph<IVertex>();
            int i = 0;
            while (i < _hashTable.Count)
            {
                KeyValuePair<IVertex,LinkedList<IVertex>> element = _hashTable.ElementAt(i);
                IVertex key = element.Key;

                if (!g.ContainsVertex(key))
                {
                    g.AddVertex(key);
                }

                LinkedList<IVertex> edges = element.Value;

                foreach (IVertex vertex in edges)
                {
                    if (!g.ContainsVertex(vertex))
                    {
                        g.AddVertex(vertex);
                    }
                    g.AddEdge(vertex, key);
                }
                i++;
            }
            return g;
        }

        public void Print()
        {
            foreach (KeyValuePair<IVertex, LinkedList<IVertex>> vertex in _hashTable)
            {
                IVertex v = vertex.Key;
                Console.WriteLine($"Key = {v}");
                foreach(IVertex u in vertex.Value)
                    Console.WriteLine($"Values = {u}");
            }
        }
    }


}
