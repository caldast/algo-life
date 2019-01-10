namespace Caldast.AlgoLife.DesignPatterns.MVC
{
    interface IFlightModel
    {
        void Initialize();
        string GetLocation();
        void SetLocation(string location);
        double GetSpeed();
        void SetSpeed(double speed);

        void RegisterObserver(ILocationObserver observer);
        void RegisterObserver(ISpeedObserver observer);

        void NotifyLocationObservers();
        
    }
}
