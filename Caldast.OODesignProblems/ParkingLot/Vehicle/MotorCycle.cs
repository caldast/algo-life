using Caldast.OODesignProblems.ParkingLot.Enums;

namespace Caldast.OODesignProblems.ParkingLot.Vehicle
{
    public class MotorCycle : Vehicle
    {
        public MotorCycle(string id)
            : base(id, VehicleSize.Compact)
        {
        }
    }
}
