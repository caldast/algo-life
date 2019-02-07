namespace Caldast.OODesignProblems.ParkingLot.ParkingSpot
{
    public class DisabledParkingSpotType : ParkingSpotType
    {
        public string TagNumber { get; }
        public DisabledParkingSpotType(string tagNumber) : base()
        {
            TagNumber = tagNumber;
        }
    }
}
