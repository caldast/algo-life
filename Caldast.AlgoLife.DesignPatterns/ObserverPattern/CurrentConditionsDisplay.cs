using System;

namespace Caldast.AlgoLife.DesignPatterns.ObserverPattern
{
    class CurrentConditionsDisplay: IDisplay, IWeatherObserver
    {
        
        private double _temperature;
        private double _humidity;

        public CurrentConditionsDisplay(IWeather weatherData)
        {          
            weatherData.Subscribe(this);
        }

        public void Display()
        {
            Console.WriteLine("Temperature: " + _temperature);
            Console.WriteLine("Humidity: " + _humidity);
        }

        public void Update(double temperature, double humidity, double pressure)
        {
           _temperature = temperature;
            _humidity = humidity;
            Display();
        }
    }
}
