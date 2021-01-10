using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caldast.AlgoLife.Graph
{
    public class SimpleGraph
    {
        private Dictionary<int, Vertex> _dict = new Dictionary<int, Vertex>();
        private List<Edge> edges = new List<Edge>();
        public bool IsDirected { get; set; }

        public SimpleGraph(bool isDirected)
        {
            IsDirected = isDirected;
        }

        public void AddVertex(int v)
        {
            if (!_dict.ContainsKey(v))
            {

                _dict.Add(v, new Vertex(v));
            }
        }
        public void AddEdge(int v1, int v2, int weight)
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
            edges.Add(e);
            vertex1.AddAdjacentVertex(e,vertex2);
            if (!IsDirected)
            {
                e = new Edge(vertex2, vertex1, IsDirected, weight);
                vertex2.AddAdjacentVertex(e, vertex1);
            }
        }

        public List<Edge> GetEdges()
        {
            return edges;
        }

        public IEnumerable<Vertex> GetVertices()
        {
            return _dict.Values;
        }

        public bool Contains(int v)
        {
            return _dict.ContainsKey(v);
        }

        public Vertex GetVertex(int id)
        {
            if (!_dict.ContainsKey(id))
                throw new Exception("Cannot find vertex");

            return _dict[id];
        }


    }

    public class Vertex
    {
        List<Edge> edges = new List<Edge>();
        List<Vertex> vertices = new List<Vertex>();
        public int Value { get; set; }

        public Vertex(int value)
        {
            Value = value;
        }

        public void AddAdjacentVertex(Edge e, Vertex v)
        {
            vertices.Add(v);
            edges.Add(e);
        }

        public List<Vertex> GetAdjacentVertices()
        {
            return vertices;
        }

        public List<Edge> GetAdjanceEdges()
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
            return Value.GetHashCode();
        }


    }
    public class Edge: IEquatable<Edge>
    {
        public Vertex Source { get; set; }
        public Vertex Destination { get; set; }

        public int Weight { get; set; }
        public bool IsDirected { get; set; }
        public Edge(Vertex source, Vertex destination)
        {
            Source = source;
            Destination = destination;
        }
        public Edge(Vertex source, Vertex destination, bool isDirected, int weight)
            : this(source, destination)
        {
            IsDirected = isDirected;
            Weight = weight;
        }

        public bool Equals(Edge other)
        {
            if(ReferenceEquals(null,other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (this.GetType() != other.GetType())
                return false;

            return  this.Source.Value == other.Source.Value
                && this.Destination.Value == other.Source.Value
                && this.Weight == other.Weight;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Edge);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + this.Source.GetHashCode();
            hash = hash * 23 + this.Destination.GetHashCode();
            return hash;
        }
    }
}
