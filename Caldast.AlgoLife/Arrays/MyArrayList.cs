using System;

namespace Caldast.AlgoLife
{
    internal class MyArrayList
    {
        private int _size = 0;
        private int[] _arr;
        private int _index = -1;
        internal MyArrayList(int size)
        {
            _size = size;
            _arr = new int[_size];            
        }
        internal void Add(int value)
        {
            _index++;
            if (_index == _size)
            {
                _size = _size == 0 ? 1 : _size * 2;
                int[] newArr = new int[_size];
                for (int i = 0; i < _arr.Length; i++)
                {
                    newArr[i] = _arr[i];
                }
                _arr = newArr;
            }
            _arr[_index] = value;
        }
        internal void Remove(int index)
        {
            if (index < 0 || index >= _size)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            int i = index;
            while (i < _size - 1)
            {
                _arr[i] = _arr[i + 1];
                i++;
            }
            _arr[i] = 0;
            _index--;
            _size--;
        }
        internal int FindElement(int element)
        {
            for (int i = 0; i <= _index; i++)
            {
                if (_arr[i] == element)
                {
                    return i;
                }
            }
            return -1;
        }
        internal int Find(int index)
        {
            if (index < 0 || index >= _size)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return _arr[index];
        }

    }
}
