using System;
using System.Collections.Generic;
using System.Linq;

namespace Caldast.AlgoLife.Graph.Prim_sAlgorithm
{
    internal class PrimsMST
    {

        internal PrimsMST() { }

        public List<Edge> FindMST(SimpleGraph graph)
        {
            var minHeapDict = new MinHeapDict<Vertex>();
            var VE = new Dictionary<Vertex, Edge>();
            var result = new List<Edge>();

            IEnumerable<Vertex> vertices = graph.GetVertices();
            foreach (Vertex v in vertices)
            {
                minHeapDict.Add(v, int.MaxValue);
            }

            Vertex startVertex = vertices.First();
            minHeapDict.DecreaseKey(startVertex, 0);

            while (minHeapDict.HeapSize != 0)
            {                
                Vertex v = minHeapDict.ExtractMin();
                if (VE.ContainsKey(v))
                {
                    result.Add(VE[v]);
                }
                foreach (Edge e in v.GetAdjanceEdges())
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
             
    }
}
