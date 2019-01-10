using System;

namespace Caldast.AlgoLife.DesignPatterns.CommandPattern.Command
{
    class NoCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Unknown command");
        }

        public void Undo()
        {
            Console.WriteLine("Unknown command");
        }
    }
}
