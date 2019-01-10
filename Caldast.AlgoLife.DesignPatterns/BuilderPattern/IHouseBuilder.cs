namespace Caldast.AlgoLife.DesignPatterns.BuilderPattern
{
    interface IHouseBuilder
    {        
        void BuildRoom();
        void BuildBasement();
        void BuildGarage();

        HouseProduct GetHouse();

    }
}
