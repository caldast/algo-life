using System;
using System.Collections.Generic;
using System.Linq;

namespace Caldast.AlgoLife.Graph
{
    class DFSGraphOperation
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
            
            _time = _time + 1;
            // DFS except root
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
            var stack = new Stack<DFSVertex<char>>();
            stack.Push(vertex);

            while (stack.Count != 0)
            {
                DFSVertex<char> u = stack.Peek();                

                LinkedList<DFSVertex<char>> vertices = graph.GetEdges(u);
                int i = 0;
                while (i < vertices.Count)
                {
                    DFSVertex<char> v = vertices.ElementAt(i);

                    if (v.Color == Color.WHITE)
                    {
                        v.Color = Color.GRAY;
                        _time = _time + 1;
                        v.Start = _time;
                        v.Parent = u;
                        stack.Push(v);

                        Console.WriteLine($"({u.Value},{v.Value})");

                        vertices = graph.GetEdges(v);
                        i = 0;
                        u = v;
                        continue;
                    }
                    else 
                    {
                        if (v.Color == Color.GRAY)
                        {
                            Console.WriteLine($"({u.Value},{v.Value}) is a Back Edge");
                        }
                        i++;
                    }
                }
                u = stack.Pop();
                _time = _time + 1;
                u.End = _time;
                u.Color = Color.BLACK;
                list.AddFirst(u);
            }
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
