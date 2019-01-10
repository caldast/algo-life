namespace Caldast.AlgoLife.DesignPatterns.CommandPattern
{
    interface ICommand
    {
        void Execute();
        void Undo();
    }
}
