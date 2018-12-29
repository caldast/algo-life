using Caldast.AlgoLife.Stack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class MyStackTests
    {
        MyStack<int> mystack = null;

        [TestInitialize]
        public void Init()
        {
            mystack = new MyStack<int>();
        }
        [TestMethod]
        public void Push_Should_Add_Values()
        {
            mystack.Push(1);
            mystack.Push(2);
            mystack.Push(3);
            mystack.Push(int.MaxValue);
            int expected = 4;
            Assert.AreEqual(expected, mystack.Count);
        }

        [TestMethod]
        public void Pop_Should_Pop_Values()
        {
            mystack.Push(1);
            mystack.Push(2);
            mystack.Pop();
            mystack.Pop();

            int expected = 0;
            Assert.AreEqual(expected, mystack.Count);
        }

        [TestMethod]
        public void Peek_Should_Show_Top_Value()
        {

            mystack.Push(1);
            mystack.Push(2);
            mystack.Push(3);
            mystack.Push(4);

            int expected = 4;
            Assert.AreEqual(expected, mystack.Peek());

        }


        [TestMethod]
        public void Count_Should_Show_Correct_Value()
        {

            mystack.Push(1);
            mystack.Push(2);
            mystack.Push(3);
            mystack.Push(4);

            int expected = 4;
            Assert.AreEqual(expected, mystack.Count);

            mystack.Pop();
            mystack.Pop();

            expected = 2;
            Assert.AreEqual(expected, mystack.Count);
        }

        [TestCleanup]
        public void Clear_Should_Clear()
        {
            mystack.Clear();
        }

    }
}
