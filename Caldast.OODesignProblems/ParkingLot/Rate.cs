namespace Caldast.OODesignProblems.ParkingLot
{
    public class Rate
    {
        public double Hour { get; }
        public double Amount { get; }
        public Rate(double hour, double amount)
        {
            Hour = hour;
            Amount = amount;
        }
    }
}
