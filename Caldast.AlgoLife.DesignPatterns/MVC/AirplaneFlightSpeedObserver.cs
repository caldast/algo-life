using System;

namespace Caldast.AlgoLife.DesignPatterns.MVC
{
    class AirplaneFlightSpeedObserver: ISpeedObserver
    {
        private readonly IFlightModel _model;
        public AirplaneFlightSpeedObserver(IFlightModel model)
        {
            _model = model;
        }

        public void Update()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine(_model.GetSpeed());
            Console.WriteLine("-------------------------------------------");
        }
    }
}
