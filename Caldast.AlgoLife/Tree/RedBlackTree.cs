﻿namespace Caldast.AlgoLife
{
    public class RedBlackTree
    {

        private void RbTransplant(RbTreeNode root, RbTreeNode u, RbTreeNode v)
        {
            if (u.Parent.Value == RbTreeNode.Nil.Value)
                root = v;
            else if (u == u.Parent.Left)
                u.Parent.Left = v;
            else u.Parent.Right = v;
            v.Parent = u.Parent;
        }

        public void RbDelete(RbTreeNode root, RbTreeNode z)
        {
            RbTreeNode y = z;
            string y_original_color = y.Color;
            RbTreeNode x = null;
            if (z.Left.Value == RbTreeNode.Nil.Value)
            {
                x = z.Right;
                RbTransplant(root, z, z.Right);
            }
            else if (z.Right.Value == RbTreeNode.Nil.Value)
            {
                x = z.Right;
                RbTransplant(root, z, z.Left);
            }
            else
            {
                y = FindMinimum(z.Right);
                y_original_color = y.Color;
                x = y.Right;
                if (y.Parent == z)
                {
                    x.Parent = y;
                }
                else
                {
                    RbTransplant(root, y, y.Right);
                    y.Right = z.Right;
                    y.Right.Parent = y;
                }
                RbTransplant(root, z, y);
                y.Left = z.Left;
                y.Left.Parent = y;
                y.Color = z.Color;
              
            }
            if (y_original_color == "BLACK")
                RBTreeDeleteFixUp(root, x);



        }

        public void RBTreeDelete(RbTreeNode root, int z)
        {
            RbTreeNode x = Find(root, z);
            RbDelete(root,x);
        }

        public RbTreeNode Find(RbTreeNode root, int value)
        {
            RbTreeNode current = root;
            while (current != null)
            {
                if (current.Value == value)
                    return current;
                else if (current.Value > value)
                    current = current.Left;
                else current = current.Right;
            }
            return null;
        }

        public RbTreeNode FindSuccessor(RbTreeNode root, RbTreeNode successorFor)
        {
            if (successorFor.Right != null)
                return FindMinimum(successorFor.Right);
            RbTreeNode current = root;
            RbTreeNode successor = null;
            while (current != null)
            {
                if (current.Value == successorFor.Value)
                {
                    return successor;
                }
                else if (current.Value > successorFor.Value)
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

        public RbTreeNode RBTreeDelete(RbTreeNode root, RbTreeNode z)
        {
            RbTreeNode x, y;

            if (z.Left.Value == RbTreeNode.Nil.Value || z.Right.Value == RbTreeNode.Nil.Value)
            {
                y = z;
            }
            else
            {
                y = FindMinimum(z);
            }

            if (y.Left.Value != RbTreeNode.Nil.Value)
            {
                x = y.Left;
            }
            else
            {
                x = y.Right;
            }

           
            x.Parent = y.Parent;

            if (y.Parent.Value == RbTreeNode.Nil.Value)
            {
                root = x;
            }
            else if (y == y.Parent.Left)
            {
                y.Parent.Left = x;
            }
            else
            {
                y.Parent.Right = x;
            }

            if (y != z)
            {
                z.Value = y.Value;
            }

            if (y.Color == "BLACK")
            {
                RBTreeDeleteFixUp(root, x);
            }
            return y;
        }

        private void RBTreeDeleteFixUp(RbTreeNode root, RbTreeNode z)
        {
            while (z != root && z.Color == "BLACK")
            {
                if (z == z.Parent.Left)
                {
                    RbTreeNode w = z.Parent.Right;
                    
                    if (w.Color =="RED")
                    {
                        // Case1
                        w.Color = "BLACK";
                        z.Parent.Color ="RED";
                        LeftRotate(root, z.Parent);
                        w = z.Parent.Right;
                    }
                    
                    if (w.Left.Color == "BLACK" && w.Right.Color == "BLACK")
                    {
                        //Case2
                        w.Color ="RED";
                        z = z.Parent;
                    }
                    else if (w.Right.Color == "BLACK")
                    {
                        //Case3->Case4
                        w.Left.Color = "BLACK";
                        w.Color ="RED";
                        RightRotate(root, w);
                        w = z.Parent.Right;
                    }
                    else
                    {
                        //Case4
                        w.Color = z.Parent.Color;
                        z.Parent.Color = "BLACK";
                        w.Right.Color = "BLACK";
                        LeftRotate(root, z.Parent);
                        z = root;
                    }
                }
                else
                {
                   
                    RbTreeNode w = z.Parent.Left;
                    if (w.Color =="RED")
                    {
                        //Case1
                        w.Color = "BLACK";
                        z.Parent.Color ="RED";
                        RightRotate(root, z.Parent);
                        w = z.Parent.Left;
                    }
                    
                    if (w.Left.Color == "BLACK" && w.Right.Color == "BLACK")
                    {
                        //Case2
                        w.Color ="RED";
                        z = z.Parent;
                    }
                    else if (w.Left.Color == "BLACK")
                    {
                        //Case3.Case4
                        w.Left.Color = "BLACK";
                        w.Color ="RED";
                        LeftRotate(root, w);
                        w = z.Parent.Left;
                    }
                    else
                    {
                        //Case4
                        w.Color = z.Parent.Color;
                        z.Parent.Color = "BLACK";
                        w.Left.Color = "BLACK";
                        RightRotate(root, z.Parent);
                        z = root;
                    }
                }
            }
            z.Color = "BLACK";
        }

        void LeftRotate(RbTreeNode root, RbTreeNode x)
        {
            RbTreeNode y = x.Right;           
            x.Right = y.Left;
            if (y.Left.Value != RbTreeNode.Nil.Value)
            {
                y.Left.Parent = x;
            }

          
            y.Parent = x.Parent;
            if (x.Parent.Value == RbTreeNode.Nil.Value)
            {
                root = y;
            }
            else if (x == x.Parent.Left)
            {
                x.Parent.Left = y;
            }
            else
            {
                x.Parent.Right = y;
            }
           
            y.Left = x;
            x.Parent = y;
        }

        void RightRotate(RbTreeNode root, RbTreeNode x)
        {
            RbTreeNode y = x.Left;
            
            x.Left = y.Right;
            if (y.Right.Value != RbTreeNode.Nil.Value)
            {
                y.Right.Parent = x;
            }
            
            y.Parent = x.Parent;
            if (x.Parent.Value == RbTreeNode.Nil.Value)
            {
                root = y;
            }
            else if (x == x.Parent.Left)
            {
                x.Parent.Left = y;
            }
            else
            {
                x.Parent.Right = y;
            }
            
            y.Right = x;
            x.Parent = y;
        }


        public RbTreeNode FindMinimum(RbTreeNode node)
        {
            RbTreeNode current = node;

            while (current.Left.Value != RbTreeNode.Nil.Value)
                current = current.Left;

            return current;
        }


    }

    public class RbTreeNode
    {
        public RbTreeNode()
        {
            var n = new RbTreeNode(null, "BLACK");
            n.Left = n;
            n.Right = n;
            n.Parent = n;
            Left = n;
            Right = n;
            Parent = n;
            Color = "BLACK";            
        }
        public RbTreeNode(int? value, string color)
        {
            Value = value;
            Color = color;          
        }
        public int? Value { get; set; }
        public RbTreeNode Left { get; set; }
        public RbTreeNode Right { get; set; }
        public RbTreeNode Parent { get; set; }

        public string Color { get; set; }

        public static RbTreeNode Nil
        {
            get
            {
                var n = new RbTreeNode(null, "BLACK");
                n.Left = n;
                n.Right = n;
                return n;
            }
        }
        

    }
}
