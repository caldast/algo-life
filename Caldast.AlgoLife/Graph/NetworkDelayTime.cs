using System;
using System.Collections.Generic;
using static Caldast.AlgoLife.Graph.Prim_sAlgorithm.PrimsMST;

namespace Caldast.AlgoLife.Graph
{
    public class NetworkDelayTime
    {

        public int GetMaxTime(int[][] times, int N, int K)
        {          

            var graph = new SimpleGraph(true);
            for (int i = 0; i < times.GetLength(0); i++)
            {
                graph.AddEdge(times[i][0], times[i][1], times[i][2]);
            }

            var minHeapDict = new MinHeapDict<Vertex>();
            var dist = new Dictionary<Vertex, int>();
            var parent = new Dictionary<Vertex, Vertex>();           

            foreach (Vertex v in graph.GetVertices())
            {
                minHeapDict.Add(v, int.MaxValue);
            }
                      

            Vertex vk = graph.GetVertex(K);
            minHeapDict.DecreaseKey(vk, 0);
            parent.Add(vk, null);


            while (minHeapDict.HeapSize > 0)
            {
                MinHeapDict<Vertex>.Node node = minHeapDict.ExtractMinNode();
                Vertex v = node.Key;

                dist.Add(v, node.Weight);

                foreach (Edge e in v.GetAdjanceEdges())
                {
                    if (!minHeapDict.Contains(e.Destination))
                        continue;

                    int newWeight = dist[e.Source] + e.Weight;

                    if (newWeight < minHeapDict.GetWeight(e.Destination))
                    {
                        minHeapDict.DecreaseKey(e.Destination, newWeight);

                        if (parent.ContainsKey(e.Destination))
                        {
                            parent[e.Destination] = e.Source;
                        }
                        else
                        {
                            parent.Add(e.Destination, e.Source);
                        }
                    }
                }
            }

            if (dist.Count != N)
                return -1;

            int maxTime = int.MinValue;

            foreach (var time in dist.Values)
            {
                maxTime = Math.Max(time, maxTime);
            }

            return maxTime == int.MaxValue ? -1 : maxTime;
        }

    }
}
