using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Caldast.AlgoLife.Tests
{
    [TestClass]
    public class MyArrayListTests
    {
        
        [TestMethod]
        public void AddTest()
        {
            var arr = new MyArrayList<int>();
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);

            Assert.AreEqual(3, arr.Count);

            arr.Add(4);
            arr.Add(5);

            Assert.AreEqual(5, arr.Count);
        }

        [TestMethod]
        public void RemoveTest()
        {
            var arr = new MyArrayList<int>();
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);

            arr.Remove(3);

            Assert.AreEqual(2, arr.Count);

            arr.Remove(2);

            Assert.AreEqual(1, arr.Count);
        }

        [TestMethod]
        public void RemoveAtTest()
        {
            var arr = new MyArrayList<int>();
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);

            arr.RemoveAt(0);

            Assert.AreEqual(2, arr.Count);

            arr.Remove(1);

            Assert.AreEqual(1, arr.Count);
        }

        [TestMethod]
        public void FindTest()
        {
            var arr = new MyArrayList<int>();
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);
            
            Assert.AreEqual(0, arr.Find(1));           
            Assert.AreEqual(2, arr.Find(3));
        }

        [TestMethod]
        public void FindAtTest()
        {
            var arr = new MyArrayList<int>();
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);

            Assert.AreEqual(2, arr.FindAt(1)); 
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => arr.FindAt(5));
        }
    }
}