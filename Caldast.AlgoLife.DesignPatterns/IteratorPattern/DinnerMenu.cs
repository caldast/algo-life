using Caldast.AlgoLife.DesignPatterns.IteratorPattern;

namespace Caldast.AlgoLife.DesignPatterns.Iterator
{
    class DinnerMenu: IMenu
    {
        private readonly MenuItem[]  _menuItems;
        int counter = 0;
        private const int MAX_SIZE = 5;
        public DinnerMenu()
        {
            _menuItems = new MenuItem[MAX_SIZE];
            Add("Cheese burger", 8);
            Add("chicken salad", 7.99);
            Add("brown rice", 5);
        }


        private void Add(string name, double cost)
        {
            if (counter < MAX_SIZE)
            {
                MenuItem item = new MenuItem(name, cost);
                _menuItems[counter++] = item;
            }
        }
        

        public IIterator CreateIterator()
        {
            return new DinnerMenuIterator(_menuItems);
        }
    }
}
