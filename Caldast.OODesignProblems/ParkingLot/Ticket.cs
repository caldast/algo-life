using System;

namespace Caldast.OODesignProblems.ParkingLot
{
    public class Ticket
    {
        public string Id { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; set; }
        public Ticket(string id, DateTime starTime)
        {
            Id = id;
            StartTime = starTime;
        }

        public double GetTotalHours()
        {
            if(EndTime<StartTime)
                throw new Exception("Invalid date range");

            return EndTime.Subtract(StartTime).TotalHours;
        }

    }
}
