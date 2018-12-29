using System;
using System.Collections.Generic;

namespace Caldast.AlgoLife
{
    class PostOrderTraversal<T>
    {
        public void IterativeUsingOneStack(TreeNode<T> treeNode)
        {
            var stack = new Stack<TreeNode<T>>();
            TreeNode<T> current = treeNode;

            do
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                TreeNode<T> top = stack.Peek().Right;

                if (top == null)
                {
                    top = stack.Pop();
                    Console.WriteLine(top.Value);

                    // if popped item is the right child, that means we have already visited 
                    // or popped left child and the one in the stack is the parent
                    // so we can simply pop out the parent too
                    while (stack.Count != 0 && top == stack.Peek().Right)
                    {
                        top = stack.Pop();
                        Console.WriteLine(top.Value);
                    }
                }
                else
                {
                    current = top;
                }


            } while (stack.Count != 0);


        }
        public void IterativeUsingTwoStacks(TreeNode<T> treeNode)
        {
            var stack = new Stack<TreeNode<T>>();
            var secondaryStack = new Stack<TreeNode<T>>();

            TreeNode<T> current = treeNode;
            stack.Push(treeNode);

            while (stack.Count != 0)
            {
                current = stack.Pop();

                secondaryStack.Push(current);

                if (current.Left != null)
                {
                    stack.Push(current.Left);
                }
                if (current.Right != null)
                {
                    stack.Push(current.Right);
                }

            }

            // print values

            while (secondaryStack.Count != 0)
            {
                Console.WriteLine(secondaryStack.Pop().Value);
            }



        }

        /// <summary>
        /// Implemented as reverse preorder with right node pushed first and then left
        /// </summary>
        /// <param name="treeNode"></param>
        public void Iterative(TreeNode<T> treeNode)
        {
            var stack = new Stack<TreeNode<T>>();
            var temp = new Stack<TreeNode<T>>();
            TreeNode<T> current = treeNode;

            while (true)
            {
                while (current != null)
                {
                    stack.Push(current);
                    if (current.Left != null)
                        temp.Push(current);

                    current = current.Right;                      
                }

                if (temp.Count == 0)
                    break;

                TreeNode<T> p = temp.Pop();
                current = p.Left;

            }

            while (stack.Count != 0)
                Console.WriteLine(stack.Pop().Value);
        }

        public void Recursive(TreeNode<T> treeNode)
        {
            if (treeNode == null)
                return;
            Recursive(treeNode.Left);
            Recursive(treeNode.Right);
            Console.WriteLine(treeNode.Value);
        }
    }
}
