using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Caldast.AlgoLife.Strings.Tests
{
    [TestClass]
    public class KMPTests
    {
        [TestMethod]
        public void HasSubstringTest()
        {
            var kmp = new KMP();
            Assert.AreEqual(6,kmp.HasSubstring("abxabcabcaby", "abcaby"));
            Assert.AreEqual(0,kmp.HasSubstring("bireng", "bir"));
            Assert.AreEqual(3, kmp.HasSubstring("bireng", "eng"));
            Assert.AreEqual(-1, kmp.HasSubstring("bireng", ""));
            Assert.AreEqual(-1, kmp.HasSubstring("bireng", "rib"));
            Assert.ThrowsException<System.ArgumentException>(()=> {
                kmp.HasSubstring(null, "biren");
            });
        }

        
    }
}