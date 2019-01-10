namespace Caldast.AlgoLife.DesignPatterns.Iterator
{
    class MenuItem
    {
        private readonly string _name;
        private readonly double _cost;
        public MenuItem(string name, double cost)
        {
            _name = name;
            _cost = cost;
        }

        public string Name {
            get
            {
                return _name;
            }
            private set { }
        }
        public double Cost
        {
            get
            {
                return _cost;
            }
            private set { }
        }
    }
}
