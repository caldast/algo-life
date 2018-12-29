using System;
using System.Collections.Generic;

namespace Caldast.AlgoLife.Graph
{
    public sealed class GraphBFSOperation
    {
        public void BFS(Graph<BFSVertex<char>> graph, BFSVertex<char> v)
        {
            LinkedList<BFSVertex<char>> vertices = graph.GetVertices();

            foreach (BFSVertex<char> u in vertices)
            {
                if (u != v)
                {
                    u.IsBlack = false;
                    u.Parent = null;
                    u.Distance = null;
                }
            }


            v.IsBlack = false;
            v.Distance = 0;
            v.Parent = null;
            BFSVisit(graph, v);

            foreach (BFSVertex<char> u in vertices)
            {
                if (!u.IsBlack && u != v)
                {
                    BFSVisit(graph, u);
                }
            }

        }

        private void BFSVisit(Graph<BFSVertex<char>> graph, BFSVertex<char> v)
        {
            v.IsBlack = true;
            var q = new Queue<BFSVertex<char>>();            
            q.Enqueue(v);

            while (q.Count != 0)
            {
                BFSVertex<char> u = q.Dequeue();
                LinkedList<BFSVertex<char>> edges = graph.GetEdges(u);
                foreach (BFSVertex<char> k in edges)
                {
                    if (!k.IsBlack)
                    {
                        k.IsBlack = true;
                        k.Parent = u;
                        k.Distance = u.Distance + 1;
                        q.Enqueue(k);
                    }
                }
            }
        }

        public void PrintPath(Graph<BFSVertex<char>> graph, BFSVertex<char> source, BFSVertex<char> destination)
        {
            if (source == destination)
                Console.WriteLine(destination.Value);
            else
            {
                PrintPath(graph, source, destination.Parent);
                Console.WriteLine(destination.Value);
            }

        }
    }
}
