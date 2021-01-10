using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caldast.AlgoLife.Graph
{
    class StronglyConnectedComponent
    {
        List<Stack<Vertex>> GetStronglyConnectedComponents(SimpleGraph g)
        {
            //perform DFS and store the finished vertices in stack
            var finishedVertices = new Stack<Vertex>();
            var visited = new HashSet<Vertex>();

            foreach (var vertex in g.GetVertices())
            {
                if (!visited.Contains(vertex))
        
                {
                    DFSUtil(g, vertex, visited, finishedVertices);
                }
            }

            SimpleGraph transposed = Transpose(g);
            visited = new HashSet<Vertex>();

            var result = new List<Stack<Vertex>>();

            while (finishedVertices.Count > 0)
            {
                var scc = new Stack<Vertex>();
                Vertex vertex = finishedVertices.Pop();

                if (!visited.Contains(vertex))        
                {
                    DFSUtil(g, vertex, visited, scc);
                    result.Add(scc);
                }
            }
            return result;
        }

        private SimpleGraph Transpose(SimpleGraph g)
        {
            var graph = new SimpleGraph(g.IsDirected);
            foreach (var edge in g.GetEdges())
            {
                graph.AddEdge(edge.Destination.Value, edge.Source.Value, edge.Weight);

            }
            return graph;
        }

        private void DFSUtil(SimpleGraph g, Vertex v, HashSet<Vertex> visited, Stack<Vertex> finished)
        {
            visited.Add(v);
            foreach (Vertex u in v.GetAdjacentVertices())
            {
                if (!visited.Contains(v))
                {
                    DFSUtil(g, u, visited, finished);
                    finished.Push(u);
                }
            }
        }

    }
}
