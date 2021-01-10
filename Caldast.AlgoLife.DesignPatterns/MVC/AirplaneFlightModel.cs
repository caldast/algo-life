using System.Collections.Generic;

namespace Caldast.AlgoLife.DesignPatterns.MVC
{
    class AirplaneFlightModel : IFlightModel
    {
        private double _speed;
        private string _location;
        private List<ILocationObserver> _locationObservers;
        private List<ISpeedObserver> _speedObservers;
        public AirplaneFlightModel()
        {
            _locationObservers = new List<ILocationObserver>();
            _speedObservers = new List<ISpeedObserver>();
        }
        public string GetLocation()
        {
            return _location;
        }

        public double GetSpeed()
        {
            return _speed;
        }

        public void Initialize()
        {
            SetLocation("Portland, OR");
            SetSpeed(70.5);
        }

        public void NotifyLocationObservers()
        {           

            foreach (var view in _locationObservers)
            {
                var observer = (ILocationObserver) view;
                observer.Update();
            }
           
        }

        public void NotifySpeedObservers()
        {          

            foreach (var view in _speedObservers)
            {
               var observer = (ISpeedObserver) view;
                observer.Update();
            }
           
        }


        public void RegisterObserver(ILocationObserver observer)
        {
            _locationObservers.Add(observer);
        }

        public void RegisterObserver(ISpeedObserver observer)
        {
            _speedObservers.Add(observer);
        }

        public void SetLocation(string location)
        {
            _location = location;
            NotifyLocationObservers();
        }

        public void SetSpeed(double speed)
        {
            _speed = speed;
            NotifySpeedObservers();
        }
    }
}
