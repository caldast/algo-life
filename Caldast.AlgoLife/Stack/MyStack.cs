using System;

namespace Caldast.AlgoLife.Stack
{
    public class MyStack<T>
    {
        private T[] _arr;
        private const int _default = 10;
        private const int _incFactor = 2;

        /// <summary>
        /// Default Constructor intializes with capacity of 10
        /// </summary>
        public MyStack()
        {
            _arr = new T[_default];
        }
        /// <summary>
        /// Initializes stack with <paramref name="capacity"/>
        /// </summary>
        /// <param name="capacity"></param>

        public MyStack(int capacity)
        {
            _arr = new T[capacity];
        }
        /// <summary>
        /// Adds <paramref name="value"/> in the stack.
        /// Amortized O(1) operation
        /// </summary>
        /// <param name="value"></param>
        public void Push(T value)
        {
            if (Count == _arr.Length)
            {
                Increase();
            }
            _arr[Count++] = value;
        }
        /// <summary>
        /// Removes top item from the stack in the FILO fashion.
        /// O(1) operation
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (Count < 0)
            {
                throw new Exception("empty");
            }
            return _arr[--Count];
        }

        /// <summary>
        /// Gets the top item from stack without removing .
        /// O(1) operation
        /// </summary>
        /// <returns></returns>

        public T Peek()
        {
            if (Count < 0)
            {
                throw new Exception("empty");
            }
            return _arr[Count-1];
        }
        /// <summary>
        /// Gets count of items in stack.
        /// O(1) operation
        /// </summary>
        public int Count { get; private set; } = 0;

        /// <summary>
        /// Creates new array as per the increment factor 
        /// so that new size = current size * factor.
        /// Copies items from current array to this new array.
        /// Updates current array ref to point to new array.
        /// </summary>
        private void Increase()
        {
            int ns = Count * _incFactor;
            var newArr = new T[ns];
            for (int i = 0; i < _arr.Length; i++)
            {
                newArr[i] = _arr[i];
            }
            _arr = newArr;
        }
        /// <summary>
        /// Empties stack. O(n) operation
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < _arr.Length; i++)
            {
                _arr[i] = default(T);
            }
            Count = 0;            
        }
    }
}
