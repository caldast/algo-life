using System;

namespace Caldast.AlgoLife.DesignPatterns.CommandPattern.Receiver
{
    /// <summary>
    /// Light: Receiver class 
    /// </summary>
    class Light
    {
        public void On()
        {
            Console.WriteLine("Light is on");
        }
        public void Off()
        {
            Console.WriteLine("Light is off");
        }
    }
}
