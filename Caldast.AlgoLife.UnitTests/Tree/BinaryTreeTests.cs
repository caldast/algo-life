using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Caldast.AlgoLife.Tree.Tests
{
    [TestClass()]
    public class BinaryTreeTests
    {
        [TestMethod()]
        public void BinaryTreeTest()
        {
            int[] arr = { 1, 2, 5, 3, 4, -1, 6 };
            var bTree = new BinaryTree<int>(arr);
            IList<int> result = bTree.LevelOrderTraversal();
            CollectionAssert.AreEqual(arr, result.ToArray<int>());
            
        }
    }
}