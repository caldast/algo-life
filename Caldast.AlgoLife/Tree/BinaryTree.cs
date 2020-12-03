using System.Collections.Generic;

namespace Caldast.AlgoLife.Tree
{
    public class BinaryTree<T>
    {
        private T[] _arr;
        public BinaryTreeNode<T> Root { get; private set; }
        
        public BinaryTree(T[] arr)
        {
            _arr = arr;
            Root = CreateRecursive(0);
        }
        private BinaryTreeNode<T> CreateRecursive(int index)
        {
            if (index >= _arr.Length)
                return null;
            var n = new BinaryTreeNode<T>(_arr[index]);
            n.Left = CreateRecursive(2*index + 1);
            n.Right = CreateRecursive(2 * index + 2);
            return n;
        }
        internal IList<T> InorderTraversal()
        {
            BinaryTreeNode<T> node = Root;
            var list = new List<T>();
            InorderTraversalUtil(node, list);
            return list;
        }

        private void InorderTraversalUtil(BinaryTreeNode<T> treeNode, List<T> lst)
        {
            if (treeNode == null)
                return;

            InorderTraversalUtil(treeNode.Left,lst);
            lst.Add(treeNode.Value);
            InorderTraversalUtil(treeNode.Right, lst);
        }

        internal IList<T> LevelOrderTraversal()
        {
            var list = new List<T>();
            var queue = new Queue<BinaryTreeNode<T>>();
            if (Root == null)
                return list;
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                int nodeCount = queue.Count;

                while (nodeCount > 0)
                {
                    BinaryTreeNode<T> n = queue.Dequeue();
                    list.Add(n.Value);
                    if (n.Left != null)
                    {
                        queue.Enqueue(n.Left);
                    }
                    if (n.Right != null)
                    {
                        queue.Enqueue(n.Right);
                    }

                    nodeCount--;
                }               
                
            }

            return list;

        }
    }
}
