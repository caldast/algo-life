using Caldast.AlgoLife.Graph.Prim_sAlgorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using static Caldast.AlgoLife.Graph.Prim_sAlgorithm.PrimsMST;

namespace UnitTestProject1
{
    [TestClass]
    public class GraphUnitTests
    {
        Graph graph = null;
        MinHeapDict minHeapDict = null;
        [TestInitialize]
        public void Initalize()
        {
            graph = new Graph(false);
            graph.AddEdge(1, 2, 5);
            graph.AddEdge(1, 3, 6);
            graph.AddEdge(2, 4, 3);
            graph.AddEdge(2, 3, 5);
            graph.AddEdge(2, 5, 2);
            graph.AddEdge(3, 4, 2);
            
            graph.AddEdge(4, 5, 3);
            graph.AddEdge(4, 6, 1);
            graph.AddEdge(5, 6, 4);

            minHeapDict = new MinHeapDict();
        }

        [TestMethod]
        public void Vertices_Values_Must_Be()
        {
            var expected = new LinkedList<Graph.Vertex>();
            for (int i = 1; i <= 6; i++)
                expected.AddLast(new Graph.Vertex(i));

            LinkedList<Graph.Vertex> actual = graph.GetVertices();
            CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void Edges_Values_Must_Be()
        //{
        //    var expected = new LinkedList<Graph.Vertex>();
        //    for (int i = 1; i <= 6; i++)
        //        expected.AddLast(new Graph.Vertex(i));

        //    LinkedList<Graph.Vertex> vertices = graph.GetVertices();

        //    foreach (Graph.Vertex v in vertices)
        //    {
        //        LinkedList<Graph.Edge> edges = v.GetAdjanceEdges();
        //    }

        //    Assert.Inconclusive();
        //}

        [TestMethod]
        public void Min_Heap_Should_Give_Min()
        {
            LinkedList<Graph.Vertex> vertices = graph.GetVertices();

            foreach (Graph.Vertex vertex in vertices)
            {
                minHeapDict.Add(vertex, int.MaxValue);
            }

            Graph.Vertex first = vertices.First();
            minHeapDict.DecreaseKey(first, 0);

            Assert.AreEqual(minHeapDict.Min(), first);
        }

        [TestMethod]
        public void Extract_Heap_Should_Give_Min()
        {
            LinkedList<Graph.Vertex> vertices = graph.GetVertices();

            foreach (Graph.Vertex vertex in vertices)
            {
                minHeapDict.Add(vertex, int.MaxValue);
            }

            Graph.Vertex expected = vertices.First();

            Graph.Vertex actual = minHeapDict.ExtractMin();

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void Find_MST_Should_Give_MST()
        {
            var primsMST = new PrimsMST();
            List<Graph.Edge> mst = primsMST.FindMST(graph);
            Assert.Inconclusive();
        }
    }
}
