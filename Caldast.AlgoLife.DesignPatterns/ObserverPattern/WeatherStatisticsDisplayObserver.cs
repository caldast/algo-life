using System;

namespace Caldast.AlgoLife.DesignPatterns.ObserverPattern
{
    class WeatherStatisticsDisplayObserver: IDisplay, IWeatherObserver
    {       
        private double _temperature;
        private double _humidity;
        private double _pressure;

        public WeatherStatisticsDisplayObserver(IWeatherSubject weatherData)
        {          
            weatherData.Subscribe(this);
        }

        public void Display()
        {
            Console.WriteLine("Temperature: " + _temperature);
            Console.WriteLine("Humidity: " + _humidity);
            Console.WriteLine("Pressure: " + _pressure);
        }

        public void Update(double temperature, double humidity, double pressure)
        {
            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;
            Display();
        }
    }
}
