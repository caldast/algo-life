using System.Collections.Generic;

namespace Caldast.OODesignProblems.ParkingLot.Repository
{
    public interface ITicketRepository
    {
        Ticket Add(Ticket ticket);
        Ticket Find(Ticket ticket);
        bool Update(Ticket ticket);
    }

    public class TicketRepository: ITicketRepository
    {
        private readonly Dictionary<string, Ticket> _tickets = new Dictionary<string, Ticket>();
        public Ticket Add(Ticket ticket)
        {
            _tickets.Add(ticket.Id, ticket);
            return ticket;
        }

        public Ticket Find(Ticket ticket)
        {
            if (_tickets.ContainsKey(ticket.Id))
                return ticket;
            return null;
        }
        public bool Update(Ticket ticket)
        {
            Ticket t = Find(ticket);
            if (t != null)
            {

                _tickets[t.Id] = ticket;
                return true;
            }

            return false;
        }
    }
}
