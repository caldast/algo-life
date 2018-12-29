namespace Caldast.AlgoLife.Graph
{
    public class IVertex<T>
    {
        BFSVertex<T> Parent { get; set; }
        T Value { get; set; }
    }


    public class DFSVertex<T> : IVertex<T>
    {
        public DFSVertex(T value)
        {
            Value = value;
        }

        public int? Start { get; set; }
        public int? End { get; set; }
        public Color Color { get; set; }
        public DFSVertex<T> Parent { get; set; }
        public T Value { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public enum Color
    {
        WHITE,
        GRAY,
        BLACK,
    }

    public class BFSVertex<T> : IVertex<T>
    {
        public BFSVertex(T value)
        {
            Value = value;
        }

        public int? Distance { get; set; }
        public bool IsBlack { get; set; }
        public BFSVertex<T> Parent { get; set; }
        public T Value { get; set; }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
