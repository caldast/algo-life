﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Caldast.AlgoLife.Strings.Tests
{
    [TestClass]
    public class RabinKarpTests
    {
        [TestMethod]
        public void HasSubstringTest()
        {
            var rabinKarp = new RabinKarp();
            Assert.AreEqual(6, rabinKarp.HasSubstring("abxabcabcaby", "abcaby"));
            Assert.AreEqual(2, rabinKarp.HasSubstring("121234578", "12345"));
            Assert.AreEqual(0, rabinKarp.HasSubstring("bireng", "bir"));
            Assert.ThrowsException<System.ArgumentException>(() =>
            {
                rabinKarp.HasSubstring(null, "biren");
            });
        }
    }
}