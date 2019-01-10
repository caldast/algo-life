using System.Collections.Generic;

namespace Caldast.AlgoLife.DesignPatterns.ObserverPattern
{
    class WeatherData: IWeather
    {
        private List<IWeatherObserver> _displays;
        public WeatherData()
        {
            _displays = new List<IWeatherObserver>();
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
            _displays.Add(display);
        }
        public void UnSubscribe(IWeatherObserver display)
        {
            _displays.Remove(display);
        }

        public void Notify()
        {
            foreach (var display in _displays)
            {
                display.Update(GetTemperature(),GetHumidity(),GetPressure());
            }
        }
    }
}
