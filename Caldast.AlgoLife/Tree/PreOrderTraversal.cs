using System;
using System.Collections.Generic;

namespace Caldast.AlgoLife
{
    class PreOrderTraversal<T>
    {

        public void Recursive(TreeNode<T> node)
        {
            if (node == null)
                return;
            Console.WriteLine(node.Value);
            Recursive(node.Left);
            Recursive(node.Right);
        }

        public void Iterative(TreeNode<T> node)
        {
            var s = new Stack<TreeNode<T>>();
            TreeNode<T> current = node;
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

                TreeNode<T> p = s.Pop();
                current = p.Right;
            }
        }
    }
       
    public class TreeNode<T>
    {
        public TreeNode(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public override string ToString()
        {
            return Value?.ToString();
        }
    }


}
