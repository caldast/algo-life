using System;

namespace Caldast.AlgoLife.Stack
{
    public class MyQueue<T>
    {
        private int _front = -1;
        private int _rear = -1;
        private T[] _arr = null;

        public MyQueue(int capacity)
        {
            _arr = new T[capacity];
        }

        public int Length => _arr.Length;

        public int Count => _rear < _front ? Length - (_front - _rear) + 1 : _rear - _front;
        public void Enqueue(T value)
        {
            if (_rear+1 == Length)
                _rear = -1;
            
            if (IsFull())
                throw new Exception($"Queue is full");
            _arr[++_rear] = value;        
        }
        public T Dequeue()
        {
            if (_front + 1 == Length)
            {
                _front = -1;
            }
            if(IsEmpty())
                throw new Exception($"Queue is empty");           
            return _arr[++_front];
           
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new Exception($"Queue is empty");
            return _arr[_front+1];
        }

        public void Clear()
        {
            for (int i = 0; i < _arr.Length; i++)
            {
                _arr[i] = default(T);
            }
            _front = -1;
            _rear = -1;
            
        }

        public bool IsFull()
        {
            return _rear + 1 == _front;
        }
        public bool IsEmpty()
        {
            return _rear  == _front;
        }
    }
}
