namespace Caldast.AlgoLife.Tree
{
    public class BinaryTreeNode<T>
    {
        public BinaryTreeNode(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public override string ToString()
        {
            return Value?.ToString();
        }
        public override int GetHashCode()
        {
            return Value == null ? 0 : Value.GetHashCode();
        }
    }     
}
