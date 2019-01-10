using Caldast.AlgoLife.DesignPatterns.CommandPattern.Receiver;

namespace Caldast.AlgoLife.DesignPatterns.CommandPattern.Command
{
    class GarageOnCommand : ICommand
    {
        private readonly Garage _garage;
        public GarageOnCommand(Garage garage)
        {
            _garage = garage;
        }
        public void Execute()
        {
            _garage.Open();
        }
        public void Undo()
        {
            _garage.Close();
        }

    }
}
