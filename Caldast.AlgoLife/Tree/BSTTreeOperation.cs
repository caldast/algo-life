using System.Collections.Generic;

namespace Caldast.AlgoLife.Tree
{
    class BSTTreeOperation<T>
    {
      
        public BinaryTreeNode<T> FindSuccessor(BinaryTreeNode<T> root, BinaryTreeNode<T> successorFor)
        {
            if (successorFor.Right != null)
                return FindMinimum(successorFor.Right);

            BinaryTreeNode<T> current = root;
            BinaryTreeNode<T> successor= null;
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

        public BinaryTreeNode<T> FindPredecessor(BinaryTreeNode<T> root,BinaryTreeNode<T> predecessorFor)
        {
            BinaryTreeNode<T> predecessor = null;
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
                BinaryTreeNode<T> current = root;
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

        public BinaryTreeNode<T> FindSuccessor(BinaryTreeNode<T> root, T value)
        {
            BinaryTreeNode<T> successorFor = Find(root, value);
            return FindSuccessor(root, successorFor);
        }

        public BinaryTreeNode<T> FindPredecessor(BinaryTreeNode<T> root, T value)
        {
            BinaryTreeNode<T> predecessorFor = Find(root, value);
            return FindPredecessor(root, predecessorFor);
        }

        public BinaryTreeNode<T> Find(BinaryTreeNode<T> root, T value)
        {
            BinaryTreeNode<T> current = root;
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

        public BinaryTreeNode<T> FindMinimum(BinaryTreeNode<T> node)
        {
            BinaryTreeNode<T> current = node;

            while (current.Left != null)
                current = current.Left;

            return current;
        }

        public void Delete(BinaryTreeNode<T> root, T value)
        {
            BinaryTreeNode<T> nodeToDelete = Find(root, value);
            Delete(root, nodeToDelete);
        }
        public void Delete(BinaryTreeNode<T> root, BinaryTreeNode<T> nodeToDelete)
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
                BinaryTreeNode<T> minimum =   FindMinimum(nodeToDelete.Right);               
                DeleteNode(root,minimum, minimum.Right ?? minimum.Left);
                nodeToDelete.Value = minimum.Value;
            }
        }

        private void DeleteNode(BinaryTreeNode<T> root, BinaryTreeNode<T> nodeToDelete, BinaryTreeNode<T> value)
        {
            BinaryTreeNode<T> prev = FindPrev(root, nodeToDelete);
            if (prev.Left == nodeToDelete)
                prev.Left = value;
            else
                prev.Right = value;
        }

        private BinaryTreeNode<T> FindPrev(BinaryTreeNode<T> root, BinaryTreeNode<T> node)
        {

            BinaryTreeNode<T> prev = null;
            BinaryTreeNode<T> current = root;
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
