namespace Caldast.AlgoLife.DesignPatterns.BuilderPattern
{
    class ConcreteHouseBuilder : IHouseBuilder
    {
        private readonly HouseProduct _houseProduct;
        public ConcreteHouseBuilder()
        {
            _houseProduct = new HouseProduct();
        }

        public void BuildBasement()
        {
            _houseProduct.SetBasement("cement basement");
        }

        public void BuildGarage()
        {
            _houseProduct.SetGarage("2 door garage");
        }

        public void BuildRoom()
        {
            _houseProduct.SetRoom("cement wall rooms");
        }

        public HouseProduct GetHouse()
        {
            return _houseProduct;
        }
    }
}
