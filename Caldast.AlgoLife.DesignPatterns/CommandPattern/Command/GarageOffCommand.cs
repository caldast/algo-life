using Caldast.AlgoLife.DesignPatterns.CommandPattern.Receiver;

namespace Caldast.AlgoLife.DesignPatterns.CommandPattern.Command
{
    class GarageOffCommand : ICommand
    {
        private readonly Garage _garage;
        public GarageOffCommand(Garage garage)
        {
            _garage = garage;
        }
        public void Execute()
        {
            _garage.Close();
        }

        public void Undo()
        {
            _garage.Open();
        }
    }
}
