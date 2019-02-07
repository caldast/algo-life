using System;
using Caldast.OODesignProblems.ParkingLot.Enums;

namespace Caldast.OODesignProblems.ParkingLot.Vehicle
{
    public abstract class Vehicle
    {
        public String Id { get; }
        public VehicleSize Size { get; }
        protected Vehicle(string id, VehicleSize size)
        {
            Id = id;
            Size = size;

        }
        
    }
}
