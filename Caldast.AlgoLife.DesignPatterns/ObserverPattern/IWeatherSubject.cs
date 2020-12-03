namespace Caldast.AlgoLife.DesignPatterns.ObserverPattern
{
    interface IWeatherSubject
    {
        void Subscribe(IWeatherObserver display);
        void UnSubscribe(IWeatherObserver display);
        void Notify();
    }
}
