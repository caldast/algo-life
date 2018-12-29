using Caldast.AlgoLife.Stack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class MyQueueTests
    {
        MyQueue<int> myQueue = null;

        [TestInitialize]
        public void Init()
        {
            myQueue = new MyQueue<int>(4);
        }
        [TestMethod]
        public void Enqueue_Should_Add_Values()
        {
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            myQueue.Enqueue(int.MaxValue);
            int expected = 4;
            Assert.AreEqual(expected, myQueue.Count);
        }

        [TestMethod]
        public void Dequeue_Should_Remove_Values()
        {
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Dequeue();
            myQueue.Dequeue();

            int expected = 0;
            Assert.AreEqual(expected, myQueue.Count);
        }

        [TestMethod]
        public void Peek_Should_Show_Top_Value()
        {

            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            myQueue.Enqueue(4);

            
            Assert.AreEqual(1, myQueue.Peek());
            myQueue.Dequeue();
            Assert.AreEqual(2, myQueue.Peek()); 
        }


        [TestMethod]
        public void Count_Should_Show_Correct_Value()
        {

            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            myQueue.Enqueue(4);

            myQueue.Enqueue(5); //override 1
            myQueue.Enqueue(6); //override 2

            int expected = 2;
            Assert.AreEqual(expected, myQueue.Count);

            myQueue.Dequeue();
            myQueue.Dequeue();

            expected = 0;
            Assert.AreEqual(expected, myQueue.Count);
        }

        [TestMethod]
        public void Clear_Should_ClearQueue()
        {
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            myQueue.Enqueue(4);
            int expected = 4;
            Assert.AreEqual(expected, myQueue.Count);

            myQueue.Clear();
            expected = 0;
            Assert.AreEqual(expected, myQueue.Count);
        }

        [TestCleanup]
        public void Clear()
        {
            myQueue.Clear();
        }

    }
}
