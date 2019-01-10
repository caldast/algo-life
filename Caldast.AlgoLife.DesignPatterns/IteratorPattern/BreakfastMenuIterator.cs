using System.Collections;
using Caldast.AlgoLife.DesignPatterns.Iterator;

namespace Caldast.AlgoLife.DesignPatterns.IteratorPattern
{
    class BreakfastMenuIterator : IIterator
    {
        private readonly ArrayList _menuItems;
        private int counter = 0;
        public BreakfastMenuIterator(ArrayList menuItems)
        {
            _menuItems = menuItems;
        }
        public MenuItem GetItem()
        {
            MenuItem item = (MenuItem) _menuItems[counter];
            counter = counter + 1;
            return item;
        }

        public bool HasNext()
        {
            if (_menuItems != null && counter < _menuItems.Count)
            {
                return true;
            }
            return false;
        }
    }
}
