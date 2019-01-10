using System;

namespace Caldast.AlgoLife.DesignPatterns.CommandPattern.Receiver
{
    class Garage
    {
        public void Open()
        {
            Console.WriteLine("Garage is open");
        }
        public void Close()
        {
            Console.WriteLine("Garage is close");
        }
    }
}
