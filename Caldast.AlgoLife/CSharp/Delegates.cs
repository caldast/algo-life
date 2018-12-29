using System;

namespace ConsoleApp100.CSharp
{
    class Delegates
    {
               
        public delegate int Operate(int x, int y);
        public int GetSum(int a, int b)
        {
            Console.WriteLine("Sum");
            return a + b;            
        }

        public int GetDiff(int a, int b)
        {
            Console.WriteLine("Diff");
            return a - b;
        }

        public int GetProduct(int a, int b)
        {
            Console.WriteLine("Prod");
            return a * b;
        }

        public void Run()
        {
            Operate operate = new Operate(GetSum);
            operate += GetDiff;
            operate += GetProduct;

            operate(3, 2);

        }

    }

    
}
