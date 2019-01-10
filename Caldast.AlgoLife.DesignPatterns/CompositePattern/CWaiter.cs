namespace Caldast.AlgoLife.DesignPatterns.CompositePattern
{
    class CWaiter
    {
        private readonly CMenuComponent _menuComponent;
        public CWaiter(CMenuComponent menuComponent)
        {
            _menuComponent = menuComponent;
        }
        public void Print()
        {
            _menuComponent.Print();
        }
    }
}
