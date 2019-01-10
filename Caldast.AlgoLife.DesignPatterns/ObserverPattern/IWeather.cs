namespace Caldast.AlgoLife.DesignPatterns.ObserverPattern
{
    interface IWeather
    {
        void Subscribe(IWeatherObserver display);
        void UnSubscribe(IWeatherObserver display);
        void Notify();
    }
}
