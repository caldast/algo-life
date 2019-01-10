using System;
using System.Collections.Generic;

namespace Caldast.AlgoLife.DesignPatterns.CommandPattern.Invoker
{
    class RemoteControl
    {
     
        private Stack<ICommand> _pastCommands;
        private Stack<ICommand> _futureCommands;
        private Stack<string> _history;
        public RemoteControl()
        {
            _pastCommands = new Stack<ICommand>();
            _futureCommands = new Stack<ICommand>();
            _history= new Stack<string>();
        }
        public void SetCommand(ICommand command)
        {
            _futureCommands.Push(command);
        }
        public void Do()
        {
            if (_futureCommands.Count > 0)
            {
               ICommand command = _futureCommands.Pop();               
               command.Execute();
               _pastCommands.Push(command);
               _history.Push("Do: " + command);
            }
        }
        public void Undo()
        {
            if (_pastCommands.Count > 0)
            {
                ICommand command = _pastCommands.Pop();
                command.Undo();
                _futureCommands.Push(command);
                _history.Push("Undo: "+ command);
            }
        }
        public void PrintHistory()
        {
            foreach (var command in _history)
            {
                Console.WriteLine(command);
            }
        }

    }
}
