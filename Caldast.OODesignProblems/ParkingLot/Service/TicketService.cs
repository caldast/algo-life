using System.Text;
using Caldast.OODesignProblems.ParkingLot.Repository;

namespace Caldast.OODesignProblems.ParkingLot.Service
{
    public interface ITicketService
    {
        Ticket Add(Ticket ticket);
        Ticket Find(Ticket ticket);
        bool Update(Ticket ticket);
        string Print(Ticket ticket);
    }

    public class TicketService: ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public Ticket Add(Ticket ticket)
        {
            return _ticketRepository.Add(ticket);
        }

        public Ticket Find(Ticket ticket)
        {
            return _ticketRepository.Find(ticket);
        }
        public bool Update(Ticket ticket)
        {
            return _ticketRepository.Update(ticket);
        }
        public string Print(Ticket ticket)
        {
            if (ticket == null)
                return null;

            var sb = new StringBuilder();
            sb.Append($"{nameof(ticket.Id)}: " + ticket.Id);
            sb.Append($"{nameof(ticket.StartTime)}: " + ticket.StartTime);
            sb.Append($"{nameof(ticket.EndTime)}: " + ticket.EndTime);
            sb.Append("Total Hours: " + ticket.GetTotalHours());

            return sb.ToString();
        }
    }
}
