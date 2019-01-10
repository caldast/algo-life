namespace Caldast.AlgoLife.DesignPatterns.BuilderPattern
{
    class TreeHouseBuilder : IHouseBuilder
    {
        private readonly HouseProduct _houseProduct;
        public TreeHouseBuilder()
        {
            _houseProduct = new HouseProduct();
        }

        public void BuildBasement()
        {
            _houseProduct.SetBasement("wood basement");
        }

        public void BuildGarage()
        {
            _houseProduct.SetGarage("below tree");
        }

        public void BuildRoom()
        {
            _houseProduct.SetGarage("wooden rooms");
        }

        public HouseProduct GetHouse()
        {
            return _houseProduct;
        }
    }
}
