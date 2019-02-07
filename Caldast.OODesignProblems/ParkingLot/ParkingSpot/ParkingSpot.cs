namespace Caldast.OODesignProblems.ParkingLot.ParkingSpot
{
    public class ParkingSpot
    {
        public Floor Floor { get; }
        public int SpotNumber { get; }

        public ParkingSpotType Type { get; }
        public ParkingSpotSize Size { get; }

        protected ParkingSpot(ParkingSpotType type,ParkingSpotSize size,
            Floor floor, int spotNumber)
        {
            Type = type;
            Size = size;
            Floor = floor;
            SpotNumber = spotNumber;
        }

    }
}
