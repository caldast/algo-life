using Caldast.OODesignProblems.ParkingLot.Service;

namespace Caldast.OODesignProblems.ParkingLot.Controller
{
    public class EntranceController
    {
        private readonly IEntranceService _entranceService;

        public EntranceController(IEntranceService entranceService)
        {
            _entranceService = entranceService;
        }

        public Entrance Add(Entrance e)
        {
           return _entranceService.AddEntrance(e);
        }
        public bool Remove(string id)
        {
            return _entranceService.RemoveEntrance(id);
        }

    }
}
