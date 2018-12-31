using Caldast.AlgoLife.Tree;
using System;
using System.Collections.Generic;

namespace Caldast.AlgoLife
{
    class PreOrderTraversal<T>
    {

        public void Recursive(BinaryTreeNode<T> node)
        {
            if (node == null)
                return;
            Console.WriteLine(node.Value);
            Recursive(node.Left);
            Recursive(node.Right);
        }

        public void Iterative(BinaryTreeNode<T> node)
        {
            var s = new Stack<BinaryTreeNode<T>>();
            BinaryTreeNode<T> current = node;
            while (true)
            {
                while (current != null)
                {
                    Console.WriteLine(current.Value);
                    s.Push(current);
                    current = current.Left;
                }

                if (s.Count == 0)
                    break;

                BinaryTreeNode<T> p = s.Pop();
                current = p.Right;
            }
        }
    }
       
 


}
