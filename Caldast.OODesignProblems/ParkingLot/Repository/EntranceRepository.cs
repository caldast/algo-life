using System;
using System.Collections.Generic;

namespace Caldast.OODesignProblems.ParkingLot.Repository
{
    public interface IEntranceRepository
    {
        Entrance AddEntrance(Entrance e);
        bool RemoveEntrance(string id);
    }

    public class EntranceRepository: IEntranceRepository
    {
        private readonly Dictionary<string, Entrance> _entrances = new Dictionary<string, Entrance>();
        public Entrance AddEntrance(Entrance e)
        {
            string newId = Guid.NewGuid().ToString();
            e.Id = newId;
            _entrances.Add(newId,e);
            return e;
        }

        public bool RemoveEntrance(string id)
        {
            if (_entrances.ContainsKey(id))
            {
                _entrances.Remove(id);
                return true;
            }

            return false;
        }

    }
}
