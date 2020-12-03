using System.Collections.Generic;

namespace Caldast.AlgoLife.DesignPatterns.ObserverPattern
{
    class WeatherDataSubject: IWeatherSubject
    {
        private List<IWeatherObserver> _observers;
        public WeatherDataSubject()
        {
            _observers = new List<IWeatherObserver>();
        }

        public double GetTemperature()
        {
            return 70;
        }
        public double GetHumidity()
        {
            return 40;
        }
        public double GetPressure()
        {
            return 14.0;
        }

        public void Subscribe(IWeatherObserver display)
        {
            _observers.Add(display);
        }
        public void UnSubscribe(IWeatherObserver display)
        {
            _observers.Remove(display);
        }

        public void Notify()
        {
            foreach (var display in _observers)
            {
                display.Update(GetTemperature(),GetHumidity(),GetPressure());
            }
        }
    }
}
