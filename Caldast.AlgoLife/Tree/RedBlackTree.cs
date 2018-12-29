namespace Caldast.AlgoLife
{
    class RedBlackTree
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
                    {//Case1
                        w.Color = "BLACK";
                        z.Parent.Color ="RED";
                        LeftRotate(root, z.Parent);
                        w = z.Parent.Right;
                    }
                    //____________Case2__________________
                    if (w.Left.Color == "BLACK" && w.Right.Color == "BLACK")
                    {
                        w.Color ="RED";
                        z = z.Parent;
                    }
                    else if (w.Right.Color == "BLACK")
                    {//Case3->Case4
                        w.Left.Color = "BLACK";
                        w.Color ="RED";
                        RightRotate(root, w);
                        w = z.Parent.Right;
                    }
                    else
                    {//Case4
                        w.Color = z.Parent.Color;
                        z.Parent.Color = "BLACK";
                        w.Right.Color = "BLACK";
                        LeftRotate(root, z.Parent);
                        z = root;
                    }
                }
                else
                {
                    //if-else
                    RbTreeNode w = z.Parent.Left;
                    if (w.Color =="RED")
                    {//Case1
                        w.Color = "BLACK";
                        z.Parent.Color ="RED";
                        RightRotate(root, z.Parent);
                        w = z.Parent.Left;
                    }
                    //____________Case2__________________
                    if (w.Left.Color == "BLACK" && w.Right.Color == "BLACK")
                    {
                        w.Color ="RED";
                        z = z.Parent;
                    }
                    else if (w.Left.Color == "BLACK")
                    {//Case3.Case4
                        w.Left.Color = "BLACK";
                        w.Color ="RED";
                        LeftRotate(root, w);
                        w = z.Parent.Left;
                    }
                    else
                    {//Case4
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

       // void RBTreeInsertFixUp(RbTreeNode tree, RbTreeNode z)
       // {
       //     while (z.Parent.Color == "RED")
       //     {
       //         if (z.Parent == z.Parent.Parent.Left)
       //         {//y在右边
       //             RbTreeNode y = z.Parent.Parent.Right;//设定y
       //             if (y.Color == "RED")
       //             {//Case1
       //                 z.Parent.Color = "BLACK";
       //                 y.Color = "BLACK";
       //                 z.Parent.Parent.Color = "RED";
       //                 z = z.Parent.Parent;
       //             }
       //             else
       //             {
       //                 if (z == z.Parent.Right)
       //                 {//Case2
       //                     z = z.Parent;//旋转会改变新结点的位置，所以要调整
       //                     LeftRotate(tree, z); //case2->case3
       //                 }
       //                 z.Parent.Color = "BLACK";//Case3
       //                 z.Parent.Parent.Color = "RED";
       //                 RightRotate(tree, z.Parent.Parent);
       //             }
       //         }
       //         else
       //         {//y在左边
       //             RbTreeNode y = z.Parent.Parent.Left;
       //             if (y.Color == "RED")
       //             {
       //                 z.Parent.Color = "BLACK";
       //                 y.Color = "BLACK";
       //                 z.Parent.Parent.Color = "RED";
       //                 z = z.Parent.Parent;
       //             }
       //             else
       //             {
       //                 if (z == z.Parent.Left)
       //                 {//Case2
       //                     z = z.Parent;//旋转会改变新结点的位置，所以要调整
       //                     RightRotate(tree, z); //case2->case3
       //                 }
       //                 z.Parent.Color = "BLACK";//Case3
       //                 z.Parent.Parent.Color = "RED";
       //                 LeftRotate(tree, z.Parent.Parent);
       //             }
       //         }//if-else
       //     }//while
       //     tree.Color = "BLACK";
       // }//RBInsertFixUp 

        
       //public void RBTreeInsert(RbTreeNode root, int k)
       // {
       //     RbTreeNode y = RbTreeNode.Nil;
       //     RbTreeNode x = root;
       //     RbTreeNode z = new RbTreeNode(null,"BLACK");
       //     z.Value = k;
       //     z.Parent = z.Left = z.Right = RbTreeNode.Nil;//初始化  

       //     //找到要插入的位置
       //     while (x != RbTreeNode.Nil)
       //     {
       //         y = x;
       //         if (z.Value < x.Value)
       //         {
       //             x = x.Left;
       //         }
       //         else
       //         {
       //             x = x.Right;
       //         }
       //     }
       //     //和周边点增加关系
       //     z.Parent = y;
       //     if (y == RbTreeNode.Nil)
       //     {
       //         root = z;
       //     }
       //     else
       //     {
       //         if (k < y.Value)
       //         {
       //             y.Left = z;
       //         }
       //         else
       //         {
       //             y.Right = z;
       //         }
       //     }
       //     z.Left = z.Right = RbTreeNode.Nil;
       //     z.Color = "RED";
       //     RBTreeInsertFixUp(root, z);
       // }


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
