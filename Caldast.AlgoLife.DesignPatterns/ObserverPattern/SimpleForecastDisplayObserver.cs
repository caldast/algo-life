using System;

namespace Caldast.AlgoLife.DesignPatterns.ObserverPattern
{
    class SimpleForecastDisplayObserver: IDisplay, IWeatherObserver
    {       
        private double _temperature;
        public SimpleForecastDisplayObserver(IWeatherSubject weatherData)
        {          
            weatherData.Subscribe(this);
        }

        public void Display()
        {
            if (_temperature > 60)
            {
                Console.WriteLine("Warm");
            }
        }

        public void Update(double temperature, double humidity, double pressure)
        {
            _temperature = temperature;
            Display();
        }
    }
}
