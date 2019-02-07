using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caldast.OODesignProblems.ParkingLot.Enums;

namespace Caldast.OODesignProblems.ParkingLot.Vehicle
{
public class Car: Vehicle
    {
        public Car(string id) : base(id, VehicleSize.Compact)
        {
        }
    }
}
