namespace Caldast.AlgoLife.DesignPatterns.BuilderPattern
{
    class EngineerDirector
    {
        private readonly IHouseBuilder _houseBuilder;
        public EngineerDirector(IHouseBuilder houseBuilder)
        {
            _houseBuilder = houseBuilder;
        }

        public void Construct()
        {
            _houseBuilder.BuildBasement();
            _houseBuilder.BuildRoom();
            _houseBuilder.BuildGarage();
        }
        public HouseProduct GetHouse()
        {
            return _houseBuilder.GetHouse();
        }
    }
}
