using System;

namespace Caldast.AlgoLife.DesignPatterns.CompositePattern
{
    class CMenuItem: CMenuComponent
    {
        private readonly string _name;
        private readonly double _cost;
        private readonly string _description;
        public CMenuItem(string name, double cost)
        {
            _name = name;
            _cost = cost;
        }

        public override string Name
        {
            get
            {
                return _name;
            }            
        }
        public override double Cost
        {
            get
            {
                return _cost;
            }
        }
       

        public override void Print()
        {
            Console.WriteLine("Name: " + Name + "\t"  +              
                "Cost: " + Cost);
        }
    }
}
