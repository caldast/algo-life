using Caldast.AlgoLife.DesignPatterns.Iterator;
using System;

namespace Caldast.AlgoLife.DesignPatterns.IteratorPattern
{
    class Waiter
    {
        private readonly IMenu _breakfastMenu;
        private readonly IMenu _dinnerMenu;

        public Waiter(IMenu breakfastMenu, IMenu dinnerMenu)
        {
            _breakfastMenu = breakfastMenu;
            _dinnerMenu = dinnerMenu;
        }
        public void PrintBreakfastMenu()
        {
            PrintMenuItem(_breakfastMenu);
        }
        public void PrintDinnerMenu()
        {            
            PrintMenuItem(_dinnerMenu);
        }
        public void PrintMenuItem(IMenu menu)
        {
            IIterator menuIterator = menu.CreateIterator();
            while (menuIterator.HasNext())
            {
                MenuItem item = menuIterator.GetItem();
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Cost);
            }
        }
    }
}
