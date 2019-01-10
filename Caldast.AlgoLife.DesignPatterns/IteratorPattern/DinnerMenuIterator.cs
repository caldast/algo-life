using Caldast.AlgoLife.DesignPatterns.Iterator;

namespace Caldast.AlgoLife.DesignPatterns.IteratorPattern
{
    class DinnerMenuIterator : IIterator
    {
        private readonly MenuItem[] _menuItems;
        private int counter = 0;
        public DinnerMenuIterator(MenuItem[] menuItems)
        {
            _menuItems = menuItems;
        }
        public MenuItem GetItem()
        {
            MenuItem item = _menuItems[counter];
            counter = counter + 1;
            return item;
        }

        public bool HasNext()
        {
            if (_menuItems != null && counter < _menuItems.Length && _menuItems[counter]!=null)
            {
                return true;
            }
            return false;

        }
    }
}
