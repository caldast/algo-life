using System;
using System.Collections.Generic;

namespace Caldast.AlgoLife.DesignPatterns.CompositePattern
{
    class CMenu : CMenuComponent
    {
        private List<CMenuComponent> _menuItems = new List<CMenuComponent>();
        private readonly string _name;
        private readonly string _description;
        private readonly double _cost;

        public override string Name
        {
            get
            {
                return _name;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
        }

        public override double Cost  
        {
            get
            {
                return _cost;
            }
        }

        public CMenu(string name, string description)
        {
            _name = name;
            _description = description;
        }
        public override void Add(CMenuComponent menu)
        {
            _menuItems.Add(menu);
        }


        public override void Print()
        {
            Console.WriteLine($"Name: {Name} Desc: {Description}");
            IEnumerator<CMenuComponent> components = _menuItems.GetEnumerator();
            while (components.MoveNext())
            {
                CMenuComponent component =  components.Current;                
                component.Print();
            }
        }
    }
}
