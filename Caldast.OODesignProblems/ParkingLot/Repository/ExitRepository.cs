using System;
using System.Collections.Generic;

namespace Caldast.OODesignProblems.ParkingLot.Repository
{
    public interface IExitRepository
    {
        Exit AddExit(Exit e);
        bool RemoveExit(string id);
    }
    public class ExitRepository: IExitRepository
    {
        private readonly Dictionary<string, Exit> _exits = new Dictionary<string, Exit>();

        public Exit AddExit(Exit e)
        {
            e.Id = new Guid().ToString();
           _exits.Add(e.Id,e);
            return e;
        }

        public bool RemoveExit(string id)
        {
            if (!_exits.ContainsKey(id))
                return false;
            _exits.Remove(id);
            return true;
        }
    }
}
