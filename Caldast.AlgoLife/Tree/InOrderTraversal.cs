using System;
using System.Collections.Generic;

namespace Caldast.AlgoLife
{
    class InOrderTraversal<T>
    {
        public void Iterative(TreeNode<T> treeNode)
        {
            var stack = new Stack<TreeNode<T>>();
            TreeNode<T> current = treeNode;

            while (true)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                if (stack.Count == 0)
                    break;

                TreeNode<T> p = stack.Pop();
                Console.WriteLine(p.Value);
                current = p.Right;
            }

        }

        public void Recursive(TreeNode<T> treeNode)
        {
            if (treeNode == null)
                return;
            Recursive(treeNode.Left);
            Console.WriteLine(treeNode.Value);
            Recursive(treeNode.Right);
        }
    }
}
