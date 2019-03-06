using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Caldast.AlgoLife.Stack.Tests
{
    [TestClass]
    public class StackProblemsTests
    {
        [TestMethod]
        public void EvaluateRpnTest()
        {
            var stackProblems = new StackProblems();
            Assert.AreEqual(15,stackProblems.EvaluateRpn("3,4,+,2,*,1,+"));

            Assert.AreEqual(1234, stackProblems.EvaluateRpn("1234"));
            Assert.AreEqual(-3, stackProblems.EvaluateRpn("-641,6,/,28,/"));
           
        }
    }
}