namespace Caldast.OODesignProblems.ParkingLot
{
    public class ParkingLot
    {
        public string Name { get; }
        public string Address { get; }
        public string Phone { get; }
        public ParkingLot(string name, string address, string phone)
        {
            Name = name;
            Address = address;
            Phone = phone;
        }

        
    }

    public class Floor
    {

        public int Number { get; }
        public Floor(int number)
        {
            Number = number;
        }

    }

  
}
