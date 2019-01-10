using System;

namespace Caldast.AlgoLife.DesignPatterns.CompositePattern
{
    abstract class CMenuComponent
    {
        public virtual void Add(CMenuComponent me)
        {
            throw new NotImplementedException();
        }
        public virtual bool Remove(CMenuComponent me)
        {
            throw new NotImplementedException();
        }
        public abstract void Print();

        public abstract string Name { get; }        
        public abstract double Cost { get; }


    }
}
