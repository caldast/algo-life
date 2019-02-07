using System.ComponentModel;

namespace Caldast.OODesignProblems.ParkingLot.Repository
{
    public interface IParkingLotRepository
    {
        ParkingLot AddLot(ParkingLot lot);
        bool Update(ParkingLot lot);
    }

    public class ParkingLotRepository: IParkingLotRepository
    {
        private readonly ParkingLot[] _parkingLot = new ParkingLot[1];
        
        public ParkingLot AddLot(ParkingLot lot)
        {
            if (_parkingLot[0] == null)
            {
                _parkingLot[0] = lot;
            }
            return _parkingLot[0];
        }

        public bool Update(ParkingLot lot)
        {
            if (_parkingLot[0] != null)
            {
                _parkingLot[0] = lot;
                return true;
            }

            return false;
        }
        
    }
}
