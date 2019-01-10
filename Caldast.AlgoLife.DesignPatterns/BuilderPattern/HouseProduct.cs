namespace Caldast.AlgoLife.DesignPatterns.BuilderPattern
{
    class HouseProduct
    {
        private string _garage;
        private string _basement;
        private string _room;
        public void SetGarage(string value)
        {
            _garage = value;
        }
        public void SetBasement(string value)
        {
            _basement = value;
        }
        public void SetRoom(string value)
        {
            _room = value;
        }

        public override string ToString()
        {
            return $"Room: {_room}, Basement: {_basement}, Garage: {_garage}";
        }
    }
}
