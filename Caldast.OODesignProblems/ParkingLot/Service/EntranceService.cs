using Caldast.OODesignProblems.ParkingLot.Repository;

namespace Caldast.OODesignProblems.ParkingLot.Service
{
    public interface IEntranceService
    {
        Entrance AddEntrance(Entrance e);
        bool RemoveEntrance(string id);
        Ticket PrintTicket();
    }

    public class EntranceService
    {
        private readonly IEntranceRepository _entranceRepository;
        private readonly ITicketService _ticketService;

        public EntranceService(IEntranceRepository entranceRepository, ITicketService ticketService)
        {
            _entranceRepository = entranceRepository;
            _ticketService = ticketService;
        }

        public Entrance AddEntrance(Entrance e)
        {
            if (string.IsNullOrEmpty(e?.Name))
                return null;

            // add additional business logic here

            return _entranceRepository.AddEntrance(e);

        }

        public bool RemoveEntrance(string id)
        {
            if (string.IsNullOrEmpty(id))
                return false;

            // add additional business logic here

            return _entranceRepository.RemoveEntrance(id);
        }

        public string PrinTicket(Ticket ticket)
        {
            return _ticketService.Print(ticket);
        }
    }
}
