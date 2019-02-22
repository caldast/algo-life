using Caldast.AlgoLife.Strings;
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

        
    }
}
