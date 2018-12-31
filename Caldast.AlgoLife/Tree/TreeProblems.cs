using System;
using System.Collections.Generic;
using System.Linq;

namespace Caldast.AlgoLife.Tree
{
    class TreeProblems
    {
        public void Flatten(BinaryTreeNode<int> root)
        {
            BinaryTreeNode<int> current = root;
            FlattenUtil(root);
        }
        BinaryTreeNode<int> prev = null;
        private void FlattenUtil(BinaryTreeNode<int> current)
        {
            if (current == null)
            {
                return;
            }

            FlattenUtil(current.Right);
            FlattenUtil(current.Left);

            current.Right = prev;
            current.Left = null;
            prev = current;
        }
        public bool IsBinaryTreeABST(BinaryTreeNode<char> root)
        {
           return IsBinaryTreeABSTHelper(root, char.MinValue, char.MaxValue);
        }
        private bool IsBinaryTreeABSTHelper(BinaryTreeNode<char> node, char min, char max)
        {
            if (node.Value <= min || node.Value > max)
                return false;
           
            if (node.Left != null)
            {
                if (!IsBinaryTreeABSTHelper(node.Left, min, node.Value))
                    return false;
            }
            if (node.Right != null)
            {
                if (!IsBinaryTreeABSTHelper(node.Right, node.Value, max))
                    return false;
            }
            return true;
        }
        public bool IsTreeBalanced(BinaryTreeNode<char> root)
        {
          return CheckHeight(root) != int.MinValue;
        }

        private int CheckHeight(BinaryTreeNode<char> node)
        {
            if (node == null)
                return -1;

            int left = CheckHeight(node.Left);
            if (left == int.MinValue)
                return int.MinValue;

            int right = CheckHeight(node.Right);
            if (right == int.MinValue)
                return int.MinValue;


            if (left > right)
            {
                return (left - right) > 1 ? int.MinValue : left + 1;
            }
            return (right - left) > 1 ? int.MinValue : right + 1;

        }

        public BinaryTreeNode<char> FindCommonAncestor(BinaryTreeNode<char> root, BinaryTreeNode<char> n1, BinaryTreeNode<char> n2)
        {
            if (root == null)
                return null;           
            else if (root == n1 || root == n2)
                return root;
            BinaryTreeNode<char> left = FindCommonAncestor(root.Left, n1, n2);
            BinaryTreeNode<char> right = FindCommonAncestor(root.Right, n1, n2);

            if (left == null)
                return right;
            else if (right == null)
                return left;
            else return root;

        }
        public List<LinkedList<int>> AllSequences(BinaryTreeNode<int> root)
        {
            List<LinkedList<int>> result = new List<LinkedList<int>>();
            if (root == null)
            {
                result.Add(new LinkedList<int>());
                return result;
            }

            LinkedList<int> prefix = new LinkedList<int>();
            prefix.AddFirst(root.Value);

            List<LinkedList<int>> leftSeq = AllSequences(root.Left);
            List<LinkedList<int>> rightSeq = AllSequences(root.Right);

            foreach (var left in leftSeq)
            {
                foreach (var right in rightSeq)
                {
                    Weave(left, right, prefix, result);
                }
            }
            return result;
        }
       
        private void Weave(LinkedList<int> list1, LinkedList<int> list2, LinkedList<int> prefix, List<LinkedList<int>> output)
        {
            if (list1.Count == 0)
            {
                LinkedList<int> result = MergeList(prefix,list2);                
                output.Add(result);
                return;
            }

            int first = list1.First();
            list1.RemoveFirst();
            prefix.AddLast(first);
            Weave(list1, list2,prefix , output);

            list1.AddFirst(first);
            prefix.Remove(first);

            if (list2.Count > 0)
            {
                int second = list2.First();
                list2.RemoveFirst();
                prefix.AddLast(second);

                Weave(list1, list2, prefix, output);

                list2.AddFirst(second);
                prefix.Remove(second);
            }

        }

        private LinkedList<int> MergeList(LinkedList<int> first, LinkedList<int> last)
        {
            var mergeList = new LinkedList<int>();

            foreach (var item in first)
            {
                mergeList.AddLast(item);
            }

            foreach (var item in last)
            {
                mergeList.AddLast(item);
            }
            return mergeList;
        }

        public int LongestPath(BinaryTreeNode<int> node)
        {
            int[] nodeData = new int[2];
            LongestPath(node, nodeData, 0);
            return nodeData[0];
        }

               
        // Checks for depth and node count
        private int LongestPath(BinaryTreeNode<int> node, int [] data , int depth)
        {           
            if (node == null || depth > 1000 || data[1] > 10000)
            {
                return 0;
            }
            
            data[1]++;

            int left = LongestPath(node.Left, data, depth + 1);
            int right = LongestPath(node.Right, data, depth + 1);

            if (depth > 1000 || data[1] > 10000)
                return 0;

            left = node.Left != null && node.Left.Value == node.Value ? left + 1 : 0;
            right = node.Right != null && node.Right.Value == node.Value ? right + 1 : 0;            

            data[0] = Math.Max(data[0], left+right);
            return Math.Max(left,right);

        }

        internal struct CompleteSubTreeSizeResult
        {
            internal bool IsComplete { get; set; }
            internal int Height { get; set; }

            internal CompleteSubTreeSizeResult(bool isComplete, int size)
            {
                IsComplete = isComplete;
                Height = size;
            }
        }

        public int GetSizeOfLargestCompleteSubTree(BinaryTreeNode<int> treeNode)
        {
            return GetSizeOfLargestCompleteSubTreeUtil(treeNode).Height;
        }

        private CompleteSubTreeSizeResult GetSizeOfLargestCompleteSubTreeUtil(BinaryTreeNode<int> treeNode)
        {
            if (treeNode == null)
                return new CompleteSubTreeSizeResult(true, -1);
            CompleteSubTreeSizeResult left = GetSizeOfLargestCompleteSubTreeUtil(treeNode.Left);
            if (!left.IsComplete)
            {
                return new CompleteSubTreeSizeResult(false, 0);
            }
            CompleteSubTreeSizeResult right = GetSizeOfLargestCompleteSubTreeUtil(treeNode.Right);
            if (!right.IsComplete)
            {
                return new CompleteSubTreeSizeResult(false, 0);
            }

            int height = Math.Max(left.Height, right.Height) + 1;

            bool isComplete = left.Height - right.Height <= 1;
            return new CompleteSubTreeSizeResult(isComplete, height);

        }


    }
}
