using Caldast.AlgoLife.UnionFind;
using System;
using System.Collections.Generic;

namespace Caldast.AlgoLife.Graph.Kruskal
{
    public class KruskalMST
    {
        public List<Edge> GetMST(SimpleGraph g)
        {
            if (g == null)
                throw new ArgumentNullException("input cannot be null");

            var disjoinSet = new DisjointSet<int>();
            foreach (Vertex v in g.GetVertices())
            {
                disjoinSet.MakeSet(v.Value);
            }

            List<Edge> edges = g.GetEdges();
            edges.Sort(new EdgeComparer());

            var result = new List<Edge>();
            foreach (Edge e in edges)
            {
                int src = e.Source.Value;
                int dest = e.Destination.Value;

                if (!AreInSameSet(disjoinSet, src, dest))
                {
                    disjoinSet.Union(src, dest);
                    result.Add(e);
                }
            }
            return result;
        }

        private bool AreInSameSet(DisjointSet<int> set, int s, int d) 
            => set.FindSet(s) == set.FindSet(d);
       

        public class EdgeComparer : IComparer<Edge>
        {
            public int Compare(Edge x, Edge y)
            {
                return x.Weight.CompareTo(y.Weight);
            }
        }

    }   
}
