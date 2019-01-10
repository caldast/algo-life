using System;

namespace Caldast.AlgoLife.DesignPatterns.MVC
{
    class AirplaneFlightLocationObserver : ILocationObserver
    {
        private readonly IFlightModel _model;
        public AirplaneFlightLocationObserver(IFlightModel model)
        {
            _model = model;
        }
        public void Update()
        {
            Console.WriteLine("******************************");
            Console.WriteLine(_model.GetLocation());
            Console.WriteLine("--******************************--");
        }
    }
}
