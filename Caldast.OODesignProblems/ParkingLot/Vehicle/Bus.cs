using Caldast.OODesignProblems.ParkingLot.Enums;

namespace Caldast.OODesignProblems.ParkingLot.Vehicle
{
    public class Bus: Vehicle
    {
        public Bus(string id)
            : base(id, VehicleSize.Large)
        {
        }
    }
}
