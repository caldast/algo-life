namespace Caldast.AlgoLife.DesignPatterns.MVC
{
    class AirplaneFlightController: IFlightController
    {
        private readonly IFlightModel _model;
        private readonly IFlightView _view;
        public AirplaneFlightController(IFlightModel model)
        {
            _model = model;
            _view = new AirplaneFlightView(model, this);
            _model.Initialize();
        }
        public void SetLocation(string location)
        {
            _model.SetLocation(location);
        }

        public void SetSpeed(double speed)
        {
            _model.SetSpeed(speed);
        }
    }
}
