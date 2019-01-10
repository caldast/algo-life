using Caldast.AlgoLife.DesignPatterns.Iterator;

namespace Caldast.AlgoLife.DesignPatterns.IteratorPattern
{
    interface IIterator
    {
        bool HasNext();
        MenuItem GetItem();
    }
}
