using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Caldast.AlgoLife.Graph.Kruskal.Tests
{
    [TestClass()]
    public class KruskalMSTShould
    {
        [TestMethod()]
        public void GiveMST()
        {
            //Arrange 
            var g = new SimpleGraph(true);    
            
            g.AddEdge(1, 2, 8);
            g.AddEdge(1, 4, 5);
            g.AddEdge(2, 3, 3);
            g.AddEdge(3, 7, 6);

            g.AddEdge(1, 5, 3);
            g.AddEdge(2, 5, 1);
            g.AddEdge(4, 5, 4);
            g.AddEdge(2, 6, 2);
            g.AddEdge(5, 6, 4);
            g.AddEdge(3, 6, 5);
            g.AddEdge(6, 7, 7);


            //Act
            var mst = new KruskalMST();
            List<Edge> edges = mst.GetMST(g);

            //Assert
            edges.Should().HaveCount(6);            
            
        }
    }
}