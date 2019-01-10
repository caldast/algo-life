namespace Caldast.AlgoLife.DesignPatterns.MVC
{
    class AirplaneFlightView : IFlightView
    {
        private readonly IFlightController _controller;
        private readonly IFlightModel _model;
        
        public AirplaneFlightView(IFlightModel model, IFlightController controller)
        { 
            _model = model;
            _controller = controller;
            _model.RegisterObserver(new AirplaneFlightLocationObserver(_model));
            _model.RegisterObserver(new AirplaneFlightSpeedObserver(_model));
        }
        

        public void SetLocation(string location)
        {
            _controller.SetLocation(location);
        }

        public void SetSpeed(double speed)
        {
            _controller.SetSpeed(speed);
        }

       
    }
}
