using Caldast.AlgoLife.Arrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class StringOperationTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var stringOp = new StringOperations();
            string expected = "";
           string actual = stringOp.LongestCommonPrefix1(new string[] { "abaa", "", "abb" });
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var stringOp = new StringOperations();
            string expected = "";
            int[] indx = new int[2];
           
            string str1 = "abdace";
            string str2 = "babce";
           // stringOp.LongestCommonSubSequence(str1,str2,indx,0);

            Assert.Inconclusive();
            
        }
    }
}
