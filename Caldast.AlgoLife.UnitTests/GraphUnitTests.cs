using System.Collections.Generic;
using System.Linq;
using Caldast.AlgoLife.Graph;
using Caldast.AlgoLife.Graph.Prim_sAlgorithm;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Caldast.AlgoLife.UnitTests
{
    [TestClass]
    public class GraphUnitTests
    {
        SimpleGraph graph = null;
        MinHeapDict<Vertex> minHeapDict = null;
        [TestInitialize]
        public void Initalize()
        {
            graph = new SimpleGraph(false);
            graph.AddEdge(1, 2, 5);
            graph.AddEdge(1, 3, 6);
            graph.AddEdge(2, 4, 3);
            graph.AddEdge(2, 3, 5);
            graph.AddEdge(2, 5, 2);
            graph.AddEdge(3, 4, 2);
            
            graph.AddEdge(4, 5, 3);
            graph.AddEdge(4, 6, 1);
            graph.AddEdge(5, 6, 4);

            minHeapDict = new MinHeapDict<Vertex>();
        }

        [TestMethod]
        public void GetVerticesReturnsCorrectVertices()
        {
            var expected = new List<Vertex>();
            for (int i = 1; i <= 6; i++)
                expected.Add(new Vertex(i));

            List<Vertex> actual = graph.GetVertices().ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

       

        [TestMethod]
        public void MinHeapShouldGiveMinValue()
        {
            List<Vertex> vertices = graph.GetVertices().ToList();

            foreach (Vertex vertex in vertices)
            {
                minHeapDict.Add(vertex, int.MaxValue);
            }

            Vertex first = vertices.First();
            minHeapDict.DecreaseKey(first, 0);

            Assert.AreEqual(minHeapDict.Min(), first);
        }

        [TestMethod]
        public void Extract_Heap_Should_Give_Min()
        {
            List<Vertex> vertices = graph.GetVertices().ToList();

            foreach (Vertex vertex in vertices)
            {
                minHeapDict.Add(vertex, int.MaxValue);
            }

            Vertex expected = vertices.First();

            Vertex actual = minHeapDict.ExtractMin();

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void Find_MST_Should_Give_MST()
        {
            var primsMST = new PrimsMST();
            List<Edge> mst = primsMST.FindMST(graph);

            mst.Should().HaveCount(5);
        }
    }
}
