using Caldast.AlgoLife.Tree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Caldast.AlgoLife.Graph;
using Caldast.AlgoLife.Arrays;
using Caldast.AlgoLife.LinkedList;
using Caldast.AlgoLife.Sorting;
using Caldast.AlgoLife.Number;
using Caldast.AlgoLife.DynamicProgramming;
using Caldast.AlgoLife.Recursion;

namespace Caldast.AlgoLife
{
    public class Program
    {
        static void Main(string[] args)
        {
            //DoBitManipulation();

            //DoSorting();

            //DoRecursion();
            // DoDynamicProgramming();
            //DoNumberProblems();
            //DoStringOperations();
           

            //DoArrayProblems();
            //DoLinkedList();
            //DoSinglyLinkedListSum();
            //DoExternalSort();

            //DoTreeProblems();
            //DoStringProblems();
            //DoTrieOperation();

            //DoSinglyLinkedListPartition();
            // DoPermutation();
            //DoNumberProblems();

            //Problems.Permute("123", 0, 2);

            //DoBFSGraphOperation();
            //DoDFSGraphOperation();
            //DoQuickSort();
            //DoRadixSort();
            //DoHeapSort();
            //DoBucketSort();
            //DoBinarySearch();
            //DoPreOrderTreeTraversal();
            //DoInOrderTreeTraversal();
            //DoPostOrderTreeTraversal();
            //DoFindSuccessor();
            //DoFindPredecessor();
            //DoDeleteNode();
            //DoRbDeleteNode();
            //Problems.PrintAllSolutionsToEquation();    
            //HashTableOperation();


            //FindLeftMostMinimumElementInMongeArray();


            // var tries = new Tries();
            // tries.Insert("stock");
            // tries.Insert("stop");
            // tries.Insert("ab");
            // tries.Insert("abc");
            // tries.Insert("abt");

            //bool isFound = tries.Search("st");
            //isFound = tries.Search("mno");
            //isFound = tries.Search("stock");

            //isFound = tries.Delete("stock");
            //isFound = tries.Delete("stop");

            // isFound = tries.Delete("abt");
            // isFound = tries.Delete("ab");
            // isFound = tries.Delete("abc");

            // isFound = tries.Delete("stop");


        }
        
        public static void DoLinkedList()
        {
            //var circularLinkedList = new CircularLinkedList();
            //circularLinkedList.AddFirst(1);

            //circularLinkedList.DeleteAllOdds();

            //var probs = new LinkedListProblems();

            //var singlyLinkedList = new SinglyLinkedList<int>();

            //int[] arr = { 0,1,2 };

            //Array.ForEach(arr, i =>
            //            singlyLinkedList.AddLast(new SinglyLinkedListNode<int>(i)));


            //SinglyLinkedListNode<int> node = probs.EvenOddMerge(singlyLinkedList.Root);



            //var singlyLinkedList = new SinglyLinkedList<int>();
            //int[] arr = {1,2,1,2};
            //Array.ForEach(arr, i =>
            //            singlyLinkedList.AddLast(new SinglyLinkedListNode<int>(i)));
            //bool node = probs.CheckPalindrome(singlyLinkedList.Root);

            //var downRightLinkedList = new LinkedListProblems.DownRightLinkedList(1)
            //{
            //    Down = new LinkedListProblems.DownRightLinkedList(2),
            //    Right = new LinkedListProblems.DownRightLinkedList(3)
            //    {
            //        Down = new LinkedListProblems.DownRightLinkedList(4)
            //    }
            //};
            //var node  = probs.Flatten(downRightLinkedList);

        }

       
        public static void DoBitManipulation()
        {   
            var b = new BitManipulation.BitManipulation();
            long a = b.Divide(int.MaxValue, 1);
            //int add = b.Add(5, 6);
            //Console.WriteLine("Add: "+ add.ToString());
        }
        public static void DoSorting()
        {
            int[] arr = new int[] {1,2,3,4 };
            //QuickSort.SortIterative(arr, 0, arr.Length - 1);
            //Console.Read();

            BubbleSort b = new BubbleSort();
            b.Sort(arr);
        }
        

        public static void DoRecursion()
        {
          
            Player p1 = new Player("A");
            Player p2 = new Player("B");
            var gm = new CoinGame(7, p1, p2);

            gm.Play(p1);         
        }
        
        public static void DoStringOperations()
        {
            var operations = new StringOperations();
            //operations.Parens(3);
            //string s1 = "elf";
            //string s2 = "whitelsaf";
            //bool result=  operations.IsSubSequence(s1, s2, s1.Length, s2.Length);
            //string s = "Mr John Smith    ";
            //string res = operations.Urlify(s.ToCharArray(), 13);            
        }
        public static void DoTreeProblems()
        {

            var treeProblems = new TreeProblems();
            
            //var treeOperation = new TreeOperation<char>();
            //var node = GetBinaryTreeNode();
            //bool isBalanced = treeProblems.IsTreeBalanced(node);

            //bool isBST = treeProblems.IsBinaryTreeABST(node);
            #region FindCommonAncestor
            //BinaryTreeNode<char> a = treeOperation.Find(node, 'A');
            //BinaryTreeNode<char> g = treeOperation.Find(node, 'G');
            //BinaryTreeNode<char> common = treeProblems.FindCommonAncestor(node, a, g);
            #endregion

            #region BSTSequences
            //var intTreeNode = GetIntTreeNode();
            //var list = treeProblems.AllSequences(intTreeNode);
            #endregion

            #region
            //var node = GetTreeNodeToFlatten();
            //treeProblems.Flatten(node);            
            #endregion

            //var intNodes = GetIntTreeNode();
            //int max = treeProblems.LongestPath(intNodes);

            var treeNode = GetIntTreeNode();
            int len =  treeProblems.GetSizeOfLargestCompleteSubTree(treeNode);
        }
        public static void DoArrayProblems()
        {
           var arrayProblems = new ArrayProblems();
            //int len = arrayProblems.RemoveElement(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2);
            //int min2 = arrayProblems.Min2(new int[] {4,2});
            //List<List<int>> subsets = arrayProblems.AllSubsets(new int[]{ 1, 2, 3, 4});
            #region TowersOfHanoi
            //Stack<int> src = new Stack<int>();
            ////src.Push(3);
            //src.Push(2);
            //src.Push(1);
            //Stack<int> dest = new Stack<int>();
            //arrayProblems.TowersOfHanoiRecursive(src, new Stack<int>(), dest);
            #endregion

            //arrayProblems.Multiply(new int[] { 1, 2, 3, 4 }, new int[] { 5, 6 });

            int[] A = new int[] {1,3,5};
            int[] B = new int[] {2, 4, 6};

            //int med = arrayProblems.GetMedian(A, B, A.Length);
            //int med = arrayProblems.GetMedianRecursive(A, B);
            //double med = arrayProblems.FindMedianSortedArrays(A, B, A.Length,B.Length);
            double med1 = arrayProblems.FindMedian1(A, B, A.Length, B.Length);

        }
        public static void DoExternalSort()
        {
            var externalSort = new ExternalSort();
            externalSort.Sort();
        }
        public static void DoTrieOperation()
        {
            var trie = new Trie.Trie();
            trie.Insert("abcd");
            trie.Insert("abn");
            trie.Insert("ghij");
            trie.Insert("ghijk");

            Console.WriteLine($"Found 'abn' ={trie.RecursiveSearchWord("abn")}");
            Console.WriteLine($"Found 'ghij' ={trie.RecursiveSearchWord("ghij")}");
            trie.Delete("ghij");
            Console.WriteLine($"Found 'ghij' ={trie.RecursiveSearchWord("ghij")}");
            Console.WriteLine($"Found 'mnop' ={trie.RecursiveSearchWord("mnop")}");


        }
        public static void DoSinglyLinkedListPartition()
        {            

            var singlyLinkedList = new SinglyLinkedList<int>();

            int[] arr = { 1,2,10,5,8,5,3 };

            Array.ForEach(arr, i => 
                        singlyLinkedList.AddFirst(new SinglyLinkedListNode<int>(i)));

            var problems = new LinkedListProblems();
            var newSinglyLinkedList = problems.Partition(singlyLinkedList.Root, 5);
            
            newSinglyLinkedList.Print();

        }

        public void DoDeleteFromSinglyLinkedListMid()
        {
            var d = new SinglyLinkedListNode<char>('d');
            var singlyLinkedList = new SinglyLinkedList<char>(d);

            var c = new SinglyLinkedListNode<char>('c');
            singlyLinkedList.AddFirst(c);

            var b = new SinglyLinkedListNode<char>('b');
            singlyLinkedList.AddFirst(b);
            var a = new SinglyLinkedListNode<char>('a');
            singlyLinkedList.AddFirst(a);

            singlyLinkedList.Print();

            var problems = new LinkedListProblems();
            problems.DeleteMiddle(b, singlyLinkedList);

            singlyLinkedList.Print();

        }

        public static void DoSinglyLinkedListSum()
        {

            var singlyLinkedList1 = new SinglyLinkedList<int>();
            var singlyLinkedList2 = new SinglyLinkedList<int>();

            int[] arr1 = { 2,3,7,1,6 };
            int[] arr2 = { 5,9,2 };

            Array.ForEach(arr1, i =>
                        singlyLinkedList1.AddFirst(new SinglyLinkedListNode<int>(i)));

            Array.ForEach(arr2, i =>
                      singlyLinkedList2.AddFirst(new SinglyLinkedListNode<int>(i)));

            var problems = new LinkedListProblems();
            var newSinglyLinkedList = problems.SumLists(singlyLinkedList1, singlyLinkedList2);

            newSinglyLinkedList.Print();

        }
        public static void DoStringProblems()
        {
            var stringOp = new StringOperations();
           

            string str1 = "abcdefghijhaadfasdf";
            string str2 = "dhff";
            // str2 should be shorter than str1
            string temp = str2;
            if (str2.Length > str1.Length)
            {
                str2 = str1;
                str1 = temp;
            }

            int len = stringOp.LongestCommonSubSequence_InEfficient(str1, str2);
        }
        public static void DoNumberProblems()
        {
            var np = new NumberProblems();
            //int[] arr = new int[] { 1, 2, 3 };
            //np.Permute(arr, 0, arr.Length-1);
            //int[] nums = np.TwoSum(new int[] {572,815,387,418,434,530,376,190,196,74,830,561,973,771,640,37,539,369,327,51,623,575,988,44,659,48,22,776,487,873,486,169,499,82,128,31,386,691,553,848,968,874,692,404,463,285,745,631,304,271,40,921,733,56,883,517,99,580,55,81,232,971,561,683,806,994,823,219,315,564,997,976,158,208,851,206,101,989,542,985,940,116,153,47,806,944,337,903,712,138,236,777,630,912,22,140,525,270,997,763,812,597,806,423,869,926,344,494,858,519,389,627,517,964,74,432,730,843,673,985,819,397,607,34,948,648,43,212,950,235,995,76,439,614,203,313,180,760,210,813,920,229,615,730,359,863,678,43,293,978,305,106,797,769,3,700,945,135,430,965,762,479,152,121,935,809,101,271,428,608,8,983,758,662,755,190,632,792,789,174,869,622,885,626,310,128,233,82,223,339,771,741,227,131,85,51,361,343,641,568,922,145,256,177,329,959,991,293,850,858,76,291,134,254,956,971,718,391,336,899,206,642,254,851,274,239,538,418,21,232,706,275,615,568,714,234,567,994,368,54,744,498,380,594,415,286,260,582,522,795,261,437,292,887,405,293,946,678,686,682,501,238,245,380,218,591,722,519,770,359,340,215,151,368,356,795,91,250,413,970,37,941,356,648,594,513,484,364,484,909,292,501,59,982,686,827,461,60,557,178,952,218,634,785,251,290,156,300,711,322,570,820,191,755,429,950,18,917,905,905,126,790,638,94,857,235,889,611,605,203,859,749,874,530,727,764,197,537,951,919,24,341,334,505,796,619,492,295,380,128,533,600,160,51,249,5,837,905,747,505,82,158,687,507,339,575,206,28,29,91,459,118,284,995,544,3,154,89,840,364,682,700,143,173,216,290,733,525,399,574,693,500,189,590,529,972,378,299,461,866,326,43,711,460,426,947,391,536,26,579,304,852,158,621,683,901,237,22,225,59,52,798,262,754,649,504,861,472,480,570,347,891,956,347,31,784,581,668,127,628,962,698,191,313,714,893}, 101);
            //int value = np.RomanToInt("");
            //string result = np.IntToText(-10002);

            //int result = np.GetMissingNumberMethod_Sum(new int[] { 1, 2, 3, 5 }, 5);
            //bool res = np.IsMatch("1010", "A");
            // np.MySqrt(2147395599);

            //uint x = 3 >> 1;
        }

        public static void DoDynamicProgramming()
        {
            //var dp = new CutRod();
            //int val = dp.Recursive(new int[] { 0, 1, 5, 8 }, 4);

            var lis = new LongestIncreasingSubsequence();
            var seq = new int[] {0,4,12,2,10,6,9,3,11,7};
            //int len = lis.LisRecursive(seq);

            LinkedList<int> longestSeq = lis.Iterative(seq);
        }

        public static void DoPermutation()
        {
            var p = new Permutation();
            var arr = new char[] { 'A','B','C','D' };
            p.FindUniquePermutation(arr);
        }

        public static void DoBFSGraphOperation()
        {
            var graph = new Graph<BFSVertex<char>>();
            var a = new BFSVertex<char>('A');
            var b = new BFSVertex<char>('B');
            var c = new BFSVertex<char>('C');
            var d = new BFSVertex<char>('D');
            var e = new BFSVertex<char>('E');
            var f = new BFSVertex<char>('F');

            graph.AddVertex(a);
            graph.AddVertex(b);
            graph.AddVertex(c);
            graph.AddVertex(d);
            graph.AddVertex(e);
            graph.AddVertex(f);

            graph.AddEdge(a, b);
            graph.AddEdge(a, c);

            graph.AddEdge(b, a);
            graph.AddEdge(b, c);
            graph.AddEdge(b, d);
            graph.AddEdge(b, e);

            graph.AddEdge(c, a);
            graph.AddEdge(c, b);
            graph.AddEdge(c, d);

            graph.AddEdge(d, b);
            graph.AddEdge(d, c);
            graph.AddEdge(d, e);


            graph.AddEdge(e, b);
            graph.AddEdge(e, d);
            graph.AddEdge(e, f);

            graph.AddEdge(f, e);

            var graphOperation = new GraphBFSOperation();
            graphOperation.BFS(graph, a);
            graphOperation.PrintPath(graph, a, f);
        }

        public static void DoDFSGraphOperation()
        {
            var graph = new Graph<DFSVertex<char>>();
            var a = new DFSVertex<char>('A');
            var b = new DFSVertex<char>('B');
            var c = new DFSVertex<char>('C');
            var d = new DFSVertex<char>('D');
            var e = new DFSVertex<char>('E');
            var f = new DFSVertex<char>('F');

            graph.AddVertex(a);
            graph.AddVertex(b);
            graph.AddVertex(c);
            graph.AddVertex(d);
            graph.AddVertex(e);
            graph.AddVertex(f);

            graph.AddEdge(a, b);
            graph.AddEdge(a, c);

            //graph.AddEdge(b, a);
            //graph.AddEdge(b, c);
            graph.AddEdge(b, d);
            //graph.AddEdge(b, e);

            //graph.AddEdge(c, a);
            graph.AddEdge(c, b);
            //graph.AddEdge(c, d);

            //graph.AddEdge(d, b);
            graph.AddEdge(d, c);
            //graph.AddEdge(d, e);


            //graph.AddEdge(e, b);
            graph.AddEdge(e, d);
            graph.AddEdge(e, f);

            graph.AddEdge(f, d);

            var graphOperation = new DFSGraphOperation();
            graphOperation.DFS(graph);
            graphOperation.Print();

            //graph.Print();

            //Graph<DFSVertex<char>> g = graph.Transpose();

            //Console.WriteLine("Transpose:");
            //g.Print();

            //var topologicalSort = new TopologicalSort();
            //topologicalSort.DFS(graph);
            //topologicalSort.Print();

        }

        public static void DoQuickSort()
        {
            var a = new int[] {1,4,9,3,2,6,8,7};
            QuickSort.SortRecursive(a, 0, 7);
            //int[] a = new int[] { 6, 2, 3, 5, 4, 1 };
            //QuickSortByMedianOf3.Sort(a, 0, 5);
        }
        public static void DoRadixSort()
        {
            int[] arr = new int[] { 16, 14, 10, 8, 7, 9, 3, 2, 4, 1 };
            RadixSort hs = new RadixSort();
            hs.Sort(arr);
        }

        public static void DoHeapSort()
        {
            int[] arr = new int[] { 16, 14, 10, 8, 7, 9, 3, 2, 4, 1 };            
            HeapSort hs = new HeapSort();
            hs.Sort(arr);
        }

        public static void DoBucketSort()
        {
            int[] arr = new int[] { 16, 14, 10, 80, 70, 90, 30, 20, 40,35,65 };
            BucketSort bs = new BucketSort();
            bs.Sort(arr);
        }
        [TestMethod]
        public void DoBinarySearch()
        {
            int[] arr = new int[] { 1,2,3,4,6,8,9,10};

            var binarySearch = new BinarySearch();

            int index = binarySearch.RecursiveSearch(arr,0,arr.Length-1,8);

            int index1 = binarySearch.IterativeSearch(arr, 8);

            Assert.AreEqual(5, index);
            Assert.AreEqual(5, index1);

            index = binarySearch.RecursiveSearch(arr, 0, arr.Length - 1, 10);

            index1 = binarySearch.IterativeSearch(arr, 10);

            Assert.AreEqual(7, index);
            Assert.AreEqual(7, index1);

            index = binarySearch.RecursiveSearch(arr, 0, arr.Length - 1, 1);
            index1 = binarySearch.IterativeSearch(arr, 1);

            Assert.AreEqual(0, index);
            Assert.AreEqual(0, index1);

            index = binarySearch.RecursiveSearch(arr, 0, arr.Length - 1, 5);
            index1 = binarySearch.IterativeSearch(arr, 5);

            Assert.AreEqual(-1, index);
            Assert.AreEqual(-1, index1);

            index = binarySearch.RecursiveSearch(arr, 0, arr.Length - 1, 15);
            index1 = binarySearch.IterativeSearch(arr, 15);

            Assert.AreEqual(-1, index);
            Assert.AreEqual(-1, index1);
        }

        public static void DoPreOrderTreeTraversal()
        {
            var r = GetBinaryTreeNode();
            var preOrder = new PreOrderTraversal<char>();
            Console.WriteLine("Recursive");
            preOrder.Recursive(r);
            Console.WriteLine("Iterative");
            preOrder.Iterative(r);
        }


        public static void DoInOrderTreeTraversal()
        {
            var r = GetBinaryTreeNode();
            var inOrder = new InOrderTraversal<char>();
            Console.WriteLine("Recursive");
            inOrder.Recursive(r);
            Console.WriteLine("Iterative");
            inOrder.Iterative(r);
        }

        public static void DoPostOrderTreeTraversal()
        {
            var r = GetBinaryTreeNode();
            var postOrder = new PostOrderTraversal<char>();
            //Console.WriteLine("Recursive");
            //postOrder.Recursive(r);
            //Console.WriteLine("Iterative using One Stack");
            //postOrder.IterativeUsingOneStack(r);
            Console.WriteLine("Iterative using Two Stacks");
            postOrder.Iterative(r);
        }

        public static void DoFindSuccessor()
        {
            var r = GetBinaryTreeNode();
            var treeOperation = new BSTOperation<char>();
            BinaryTreeNode<char> successor = treeOperation.FindSuccessor(r, 'B');
            Console.WriteLine($"Successor = {successor.Value} For 'B'");

            successor = treeOperation.FindSuccessor(r, 'E');
            Console.WriteLine($"Successor = {successor.Value} For 'E'");

            successor = treeOperation.FindSuccessor(r, 'C');
            Console.WriteLine($"Successor = {successor.Value} For 'C'");


            successor = treeOperation.FindSuccessor(r, 'G');
            Console.WriteLine($"Successor = {successor.Value} For 'G'");

            successor = treeOperation.FindSuccessor(r, 'F');
            Console.WriteLine($"Successor = {successor.Value} For 'F'");

        }

        public static void DoFindPredecessor()
        {
            var r = GetBinaryTreeNode();
            var treeOperation = new BSTOperation<char>();

            BinaryTreeNode<char> predeccessor = treeOperation.FindPredecessor(r, 'B');
            Console.WriteLine($"Predeccessor = {predeccessor.Value} For 'B'");

            predeccessor = treeOperation.FindPredecessor(r, 'E');
            Console.WriteLine($"Predeccessor = {predeccessor.Value} For 'E'");

            predeccessor = treeOperation.FindPredecessor(r, 'C');
            Console.WriteLine($"Predeccessor = {predeccessor.Value} For 'C'");


            predeccessor = treeOperation.FindPredecessor(r, 'G');
            Console.WriteLine($"Predeccessor = {predeccessor.Value} For 'G'");

            predeccessor = treeOperation.FindPredecessor(r, 'F');
            Console.WriteLine($"Predeccessor = {predeccessor.Value} For 'F'");

        }

        public static void DoDeleteNode()
        {
            var r = GetBinaryTreeNode();

            var treeOperation = new BSTOperation<char>();

            treeOperation.Delete(r, 'F');

        }


      
        private static void DoRbDeleteNode()
        {
            var rbTree = new RedBlackTree();

            RbTreeNode root = GetRbTreeNode();
            rbTree.RBTreeDelete(root, 38);
            rbTree.RBTreeDelete(root, 41);
        }
        private static RbTreeNode GetRbTreeNode()
        {
            var nil = new RbTreeNode();

            var root = new RbTreeNode(38, "BLACK");
            root.Parent = nil;
                 
            

            var left = new RbTreeNode(31, "BLACK")
            {

                Parent = root
            };
            nil = new RbTreeNode();
        
            left.Left = nil;
            left.Right = nil;

            root.Left = left;


            var right = new RbTreeNode(41, "BLACK");

            nil = new RbTreeNode();
            right.Parent = root;

            right.Left = nil;
            right.Right = nil;

            root.Right = right;

            //var rl = new RbTreeNode(20, "BLACK")
            //{

            //    Parent = right
            //};
            //nil = new RbTreeNode(null, "BLACK");
            //nil.Parent = rl;
            //rl.Left = nil;
            //rl.Right = nil;

            //var rr = new RbTreeNode(38, "BLACK")
            //{            
            //    Parent = right
            //};
            //nil = new RbTreeNode(null, "BLACK");
            //nil.Parent = rr;
            //rr.Left = nil;
            //rr.Right = nil;

            //right.Left = rl;
            //right.Right = rr;

            //var r = new RbTreeNode(38, "BLACK")
            //{
            //    //Left = left,
            //    //Right = right,
            //    Parent = RbTreeNode.Nil
            //};
            //left.Parent = r;
            //right.Parent = r;
            //r.Left = left;
            //r.Right = right;

            return root;
        }

        private static BinaryTreeNode<int> GetIntTreeNode()
        {

            var _1 = new BinaryTreeNode<int>(1)
            {
                Left = new BinaryTreeNode<int>(2)
                {
                    Left = new BinaryTreeNode<int>(4)
                    {
                        Left = new BinaryTreeNode<int>(8)
                        {
                            Left = new BinaryTreeNode<int>(10)
                        },
                        Right = new BinaryTreeNode<int>(9)
                    },
                    Right = new BinaryTreeNode<int>(5)
                },

                Right = new BinaryTreeNode<int>(3)
               
            };

            return _1;

        }

        private static BinaryTreeNode<char> GetBinaryTreeNode()
        {
            var r = new BinaryTreeNode<char>('F');
            var b = new BinaryTreeNode<char>('B');
            b.Left = new BinaryTreeNode<char>('A');
            var d = new BinaryTreeNode<char>('D');
            var c = new BinaryTreeNode<char>('C');
            d.Left = c;
            var e = new BinaryTreeNode<char>('E');            
            d.Right = e;

            b.Right = d;
            r.Left = b;

            var g = new BinaryTreeNode<char>('G');

            var i = new BinaryTreeNode<char>('I');
            //i.Left = h

            //var j = new BinaryTreeNode<char>('J');
            //var k = new BinaryTreeNode<char>('K');

            //var l = new BinaryTreeNode<char>('L');
            //j.Right = l;
            //var m = new BinaryTreeNode<char>('M');
            //l.Right = m;
            //j.Left = k;
            //i.Right = j;

            var h = new BinaryTreeNode<char>('H');
            h.Right = i;
            h.Left = g;
            r.Right = h;
            return r;
        }

        private static BinaryTreeNode<int> GetBinaryTreeNodeToFlatten()
        {
            var root = new BinaryTreeNode<int>(1);

            var rl = new BinaryTreeNode<int>(2);
            rl.Left = new BinaryTreeNode<int>(3);
            rl.Right = new BinaryTreeNode<int>(4);
            root.Left = rl;

            var rr = new BinaryTreeNode<int>(5);
            rr.Right = new BinaryTreeNode<int>(6);
            root.Right = rr;

            return root;

        }
        public static void HashTableOperation()
        {
            MyHashTable<string, string> hashTable = new MyHashTable<string, string>();
            hashTable.Add("yoyo", "test1");
            hashTable.Add("hello", "test2");
            hashTable.Add("jojo", "test3");
            hashTable.Add("hoho", "test4");

            hashTable.Remove("jojo");
            hashTable.Remove("hoho");

        }

        public static void FindLeftMostMinimumElementInMongeArray()
        {
            //int[][] mongeArray = new int[][] { new int[] { 37, 23, 22, 32 },
            //                                   new int[] { 21, 6, 5, 10 },
            //                                   new int[] { 53, 34, 30, 31 },
            //                                   new int[] { 32, 13, 9, 6 },
            //                                   new int[] { 43, 21, 15, 8 }
            //                                  };
            int[][] mongeArray = new int[][] { new int[] { 10, 17, 13, 28,33 },
                                               new int[] { 17, 22, 16, 29, 23 },
                                               new int[] { 24, 28, 22, 34,24 },
                                               new int[] { 11, 13, 6, 17,7 },
                                               new int[] { 45, 44, 32, 37,23 },
                                               new int[] { 36, 33, 19, 21,6 },
                                               new int[] { 75, 66, 51, 53,34 },
                                              };
            int rows = 7;
            int columns = 5;
            int factor = 1;
            int[] leftMost = new int[rows];
            MongeArray m = new MongeArray();
            m.DivideAndConquereMonge(mongeArray, leftMost, rows, factor, columns);


        }
        public void Sort()
        {
            //MergeSort m = new MergeSort();
            //int [] arrayToSort = new int[] { 2, 1, 4, 3, 7, 10, 8, 9, 11 };
            //m.Sort(arrayToSort, 0, 8);
            //int[] arrayToMerge = new int[] { 1,2,3,4,7,8,9,10,11};

            // m.Merge(arrayToSort, 0, 4, 8);

            //var y = arrayToSort;
        }
        public void MaxContiniousSubArray()
        {

            //MaxContiniousSubArray s = new MaxContiniousSubArray();
            //var one = new int[] { -5, -4, -3, 2, -1, 3, -7, 3, 5 };
            //var two = new int[] { -5, -4, -3, 2, -1, 3 };
            //var three = new int[] { 13, -3, -25, 20, -3, -16, -23, 18, 20, -7, 12, -5, -22, 15, -4, -7 };
            //var four = new int[] { -2, -1, -3, -4, 5, -4, 7 };
            //var five = new int[] { };
            //var six = new int[] { -10 };
            //var maxSum=  s.Find(one);
            //var maxSum1 = s.FindUsingBruteForce(one);
        }
        public void MatrixMultiplication()
        {
            MatrixMultiplication m = new MatrixMultiplication();

            //var a = new int[2, 2];
            //a[0, 0] = 1;
            //a[0, 1] = 2;
            //a[1, 0] = 3;
            //a[1, 1] = 4;

            var a = new int[4, 4];
            a[0, 0] = 1;
            a[0, 1] = 2;
            a[0, 2] = 3;
            a[0, 3] = 4;

            a[1, 0] = 2;
            a[1, 1] = 3;
            a[1, 2] = 4;
            a[1, 3] = 1;


            a[2, 0] = 3;
            a[2, 1] = 4;
            a[2, 2] = 1;
            a[2, 3] = 2;


            a[3, 0] = 4;
            a[3, 1] = 1;
            a[3, 2] = 2;
            a[3, 3] = 3;


            var matrixA = new Matrix(4);
            matrixA.Data = a;

            //var b = new int[2, 2];
            //b[0, 0] = 5;
            //b[0, 1] = 6;
            //b[1, 0] = 7;
            //b[1, 1] = 8;

            var b = new int[4, 4];
            b[0, 0] = 2;
            b[0, 1] = 0;
            b[0, 2] = 1;
            b[0, 3] = 7;

            b[1, 0] = 0;
            b[1, 1] = 1;
            b[1, 2] = 7;
            b[1, 3] = 2;


            b[2, 0] = 1;
            b[2, 1] = 7;
            b[2, 2] = 2;
            b[2, 3] = 0;


            b[3, 0] = 7;
            b[3, 1] = 2;
            b[3, 2] = 0;
            b[3, 3] = 1;

            var matrixB = new Matrix(4);
            matrixB.Data = b;

            var c = new int[4, 4];
            var matrixC = new Matrix(4);


            m.StrassenMatrixMultiplication(matrixA, matrixB, matrixC);
        }
    }
    class Board
    {
        private int _width;
        private int _height;

        private Tile[,] _tiles;
        public Board(int width, int height)
        {
            _width = width;
            _height = height;
            _tiles = new Tile[width, height];
            Initialize();
        }
        public Tile TileAt(Point p)
        {
            return _tiles[p.X, p.Y];
        }

        public void AddUnit(Point p, Unit u)
        {
            TileAt(p).AddUnit(u);
        }
        public void RemoveUnit(Point p, Unit u)
        {
            TileAt(p).AddUnit(u);
        }

        public IEnumerable<Unit> GetUnits(Point p)
        {
            return TileAt(p).GetUnits();
        }

        public Terrain GetTerrain(Point p)
        {
            return TileAt(p).GetTerrain();
        }

        private void Initialize()
        {
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    _tiles[i, j] = new Tile(new Point(i, j));
                }
            }
        }

    }
    class Tile
    {
        private Point _position;
        private List<Unit> _units;
        private Terrain _terrain;
        public Tile(Point position)
        {
            _position = position;
            _units = new List<Unit>();
        }

        public void AddUnit(Unit u)
        {
            _units.Add(u);
        }
        public void RemoveUnit(Unit u)
        {
            _units.Remove(u);
        }
        public void SetTerrain(Terrain terrain)
        {
            _terrain = terrain;
        }
        public Terrain GetTerrain()
        {
            return _terrain;
        }
        public IEnumerable<Unit> GetUnits()
        {
            return _units;
        }
    }
    class Unit
    {

    }

    class Terrain
    {

    }
    struct Point
    {

        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

    }

    abstract class Movement
    {
        public void Move()
        {
            // check if its legal
            if (IsLegalMove())
            {
                // 
            }
        }
        private bool IsLegalMove()
        {
            // check the bounds
            return false;
        }
    }


    class Test
    {
        public string Name { get; set; }
    }
}
