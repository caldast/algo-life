namespace Caldast.OODesignProblems.ParkingLot.Users
{
    using Vehicle;
    public class Customer
    {
        public Ticket Ticket { get; }
        public Vehicle Vehicle { get; }
        public Customer(Vehicle v, Ticket t)
        {
            Ticket = t;
            Vehicle = v;
        }

    }
}
