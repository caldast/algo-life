namespace Caldast.AlgoLife.DesignPatterns.ObserverPattern
{
    interface IWeatherObserver
    {
        void Update(double temperature, double humidity, double pressure);
    }
}
