using Caldast.OODesignProblems.ParkingLot.Enums;

namespace Caldast.OODesignProblems.ParkingLot.ParkingSpot
{
    public abstract class ParkingSpotSize
    {
        public abstract VehicleSize Size { get; }
        public  abstract double Area { get; }
    }

    public class CompactParkingSpot:  ParkingSpotSize
    {
        public override VehicleSize Size => VehicleSize.Compact;
        public override double Area => 18 * 9;
    }

    public class MediumParkingSpot : ParkingSpotSize
    {
        public override VehicleSize Size => VehicleSize.Medium;
        public override double Area => 25 * 15;
    }

    public class LargeParkingSpot : ParkingSpotSize
    {
        public override VehicleSize Size => VehicleSize.Medium;
        public override double Area => 40 * 25;
    }
}
