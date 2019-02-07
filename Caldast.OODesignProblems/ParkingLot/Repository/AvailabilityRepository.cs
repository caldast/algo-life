using System.Collections.Generic;
using System.Resources;
using Caldast.OODesignProblems.ParkingLot.Enums;

namespace Caldast.OODesignProblems.ParkingLot.Repository
{
    using Vehicle;
    using ParkingSpot;
    public interface IAvailability
    {
        ParkingSpot GetAvailable(Vehicle vehicle);
        ParkingSpot GetAvailable(Vehicle vehicle, Floor floor);
    }

    class AvailabilityRepository: IAvailability
    {

        private readonly Dictionary<int, Dictionary<int,Stack<ParkingSpot>>> _parkingSpots
        = new Dictionary<int, Dictionary<int, Stack<ParkingSpot>>>();

        /// <summary>
        /// Look at Vehicle Size and then the floor
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public ParkingSpot GetAvailable(Vehicle vehicle)
        {
            for (int i = (int)vehicle.Size; i < _parkingSpots.Count; i++)
            {
                for (int j = 1; j <= _parkingSpots[i].Count; j++)
                {
                    if (_parkingSpots[i][j].Count > 0)
                    {
                        return _parkingSpots[i][j].Pop();
                    }
                }
            }

            return null;
        }

       

        public ParkingSpot GetAvailable(Vehicle vehicle, Floor floor)
        {
            for (int i = (int)vehicle.Size; i < _parkingSpots.Count; i++)
            {
                Stack<ParkingSpot> st = _parkingSpots[i][floor.Number];

                return st.Pop();
            }

            return null;
        }
    }
}
