using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Caldast.AlgoLife.UnitTests
{
    [TestClass]
    public class NumberProblems
    {
        [TestMethod]
        public void Reverse_Number_Negative_Zero_Should_Produce_Negative_Zero()
        {
            var number = new Caldast.AlgoLife.Number.NumberProblems();           
            int expected =  -0;
            int actual = number.Reverse(-0);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Reverse_Number_12345_Should_Produce_54321()
        {
            var number = new Caldast.AlgoLife.Number.NumberProblems();
            int expected = 12345;
            int actual = number.Reverse(54321);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Reverse_Number_Negative_Should_Produce_Negative_Reverse()
        {
            var number = new Caldast.AlgoLife.Number.NumberProblems();
            int expected = -98765432;
            int actual = number.Reverse(-23456789);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Reverse_Number_All_Duplicate_Should_Produce_Same()
        {
            var number = new Caldast.AlgoLife.Number.NumberProblems();
            int expected = -9999999;
            int actual = number.Reverse(expected);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Reverse_Number_Few_Duplicate_Should_Produce_Valid_Result()
        {
            var number = new Caldast.AlgoLife.Number.NumberProblems();
            int expected = 12233445;
            int actual = number.Reverse(54433221);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Reverse_Number_Int_Max_Should_Produce_Zero()
        {
            var number = new Caldast.AlgoLife.Number.NumberProblems();
            int expected = 0;
            int actual = number.Reverse(int.MaxValue);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Reverse_Number_120_Should_Produce_21()
        {
            var number = new Caldast.AlgoLife.Number.NumberProblems();
            int expected = 21;
            int actual = number.Reverse(120);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Number_Check()
        {
            
            var number = new Caldast.AlgoLife.Number.NumberProblems();
            int expected = 2147483641;
            int actual = number.Reverse(1463847412);
            Assert.AreEqual(expected, actual);
        }
    }
}
