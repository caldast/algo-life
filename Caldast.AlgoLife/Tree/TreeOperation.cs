using System.Collections.Generic;

namespace Caldast.AlgoLife.Tree
{
    class TreeOperation<T>
    {
      
        public TreeNode<T> FindSuccessor(TreeNode<T> root, TreeNode<T> successorFor)
        {
            if (successorFor.Right != null)
                return FindMinimum(successorFor.Right);

            TreeNode<T> current = root;
            TreeNode<T> successor= null;
            while (current != null)
            {
                if (Comparer<T>.Default.Compare(current.Value, successorFor.Value) == 0)
                {
                    return successor;
                }
                else if (Comparer<T>.Default.Compare(current.Value, successorFor.Value)>0)
                {
                    successor = current;
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }
            return null;
        }

        public TreeNode<T> FindPredecessor(TreeNode<T> root,TreeNode<T> predecessorFor)
        {
            TreeNode<T> predecessor = null;
            // If left subtree is present
            if (predecessorFor.Left != null)
            {
                predecessor = predecessorFor.Left;

                while (predecessor.Right != null)
                {
                    predecessor = predecessor.Right;
                }
            }
            // search node from the root and where we take the last right is the predecessor
            else
            {
                TreeNode<T> current = root;
                while (current != null)
                {
                    if (Comparer<T>.Default.Compare(current.Value, predecessorFor.Value) == 0)
                    {
                        return predecessor;
                    }
                    else if (Comparer<T>.Default.Compare(current.Value, predecessorFor.Value) > 0)
                    {
                        current = current.Left;
                    }
                    else
                    {
                        predecessor = current;
                        current = current.Right;
                    }
                }

            }
            return predecessor;
        }

        public TreeNode<T> FindSuccessor(TreeNode<T> root, T value)
        {
            TreeNode<T> successorFor = Find(root, value);
            return FindSuccessor(root, successorFor);
        }

        public TreeNode<T> FindPredecessor(TreeNode<T> root, T value)
        {
            TreeNode<T> predecessorFor = Find(root, value);
            return FindPredecessor(root, predecessorFor);
        }

        public TreeNode<T> Find(TreeNode<T> root, T value)
        {
            TreeNode<T> current = root;
            while (current != null)
            {
                if (Comparer<T>.Default.Compare(current.Value,value)==0)
                    return current;
                else if (Comparer<T>.Default.Compare(current.Value, value)>0)
                    current = current.Left;
                else current = current.Right;               
            }
            return null;
        }

        public TreeNode<T> FindMinimum(TreeNode<T> node)
        {
            TreeNode<T> current = node;

            while (current.Left != null)
                current = current.Left;

            return current;
        }

        public void Delete(TreeNode<T> root, T value)
        {
            TreeNode<T> nodeToDelete = Find(root, value);
            Delete(root, nodeToDelete);
        }
        public void Delete(TreeNode<T> root, TreeNode<T> nodeToDelete)
        {            
            if (nodeToDelete.Left == null)
            {
                DeleteNode(root, nodeToDelete, nodeToDelete.Right);
            }
            else if (nodeToDelete.Right == null)
            {
                DeleteNode(root, nodeToDelete, nodeToDelete.Left);
            }
            else
            {
                TreeNode<T> minimum =   FindMinimum(nodeToDelete.Right);               
                DeleteNode(root,minimum, minimum.Right ?? minimum.Left);
                nodeToDelete.Value = minimum.Value;
            }
        }

        private void DeleteNode(TreeNode<T> root, TreeNode<T> nodeToDelete, TreeNode<T> value)
        {
            TreeNode<T> prev = FindPrev(root, nodeToDelete);
            if (prev.Left == nodeToDelete)
                prev.Left = value;
            else
                prev.Right = value;
        }

        private TreeNode<T> FindPrev(TreeNode<T> root, TreeNode<T> node)
        {

            TreeNode<T> prev = null;
            TreeNode<T> current = root;
            while (current != null)
            {
                if (Comparer<T>.Default.Compare(current.Value, node.Value)==0)
                {
                    break;
                }
                else if (Comparer<T>.Default.Compare(current.Value, node.Value) > 0)
                {
                    prev = current;
                    current = current.Left;
                }
                else 
                {
                    prev = current;
                    current = current.Right;
                }

            }
            return prev;
        }
    }
}
