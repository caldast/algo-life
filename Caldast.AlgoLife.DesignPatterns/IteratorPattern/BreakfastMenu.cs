using Caldast.AlgoLife.DesignPatterns.IteratorPattern;
using System.Collections;

namespace Caldast.AlgoLife.DesignPatterns.Iterator
{
    class BreakfastMenu: IMenu
    {
        protected readonly ArrayList _menuItems;
        public BreakfastMenu()
        {
            _menuItems = new ArrayList();
            Add("double pancake", 10);
            Add("pancake", 5);
            Add("coffee", 2.5);
        }

        private void Add(string name, double cost)
        {
            MenuItem item = new MenuItem(name, cost);
            _menuItems.Add(item);
        }        

        public IIterator CreateIterator()
        {
            return new BreakfastMenuIterator(_menuItems);
        }
    }
}
