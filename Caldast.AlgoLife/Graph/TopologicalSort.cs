using System;
using System.Collections.Generic;

namespace Caldast.AlgoLife.Graph
{
    class TopologicalSort
    {
        private int _time = 0;
        private LinkedList<DFSVertex<char>> list;
        public void DFS(Graph<DFSVertex<char>> graph)
        {
            var vertices = graph.GetVertices();
            list = new LinkedList<DFSVertex<char>>();
            // Initialize
            foreach (DFSVertex<char> vertex in vertices)
            {
                vertex.Color = Color.WHITE;
                vertex.Parent = null;
                vertex.Start = null;
                vertex.End = null;
            }            
            
            foreach (DFSVertex<char> vertex in vertices)
            {
                if (vertex.Color == Color.WHITE)
                {
                    DFSVisit(graph, vertex);
                }
            }
        }
        private void DFSVisit(Graph<DFSVertex<char>> graph, DFSVertex<char> vertex)
        {
            _time = _time + 1;
            vertex.Start = _time;
            LinkedList<DFSVertex<char>> vertices = graph.GetEdges(vertex);

            foreach (DFSVertex<char> v in vertices)
            {
                if (v.Color == Color.WHITE)
                {
                    v.Color = Color.GRAY;                   
                    v.Parent = vertex;
                    DFSVisit(graph, v);
                }
            }
            vertex.Color = Color.BLACK;
            _time = _time + 1;
            vertex.End = _time;
            list.AddFirst(vertex);
        }

        public void Print()
        {
            foreach (DFSVertex<char> vertex in list)
            {
                Console.WriteLine($"Key = {vertex.Value}, Start = {vertex.Start}, End = {vertex.End}");
            }
        }
    }
}
