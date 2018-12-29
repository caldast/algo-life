using System;

namespace Caldast.AlgoLife.Arrays
{
    internal class ArrayListTemp
    {
        private int[] _arr;
        private int _count;

        internal ArrayListTemp(int capacity)
        {
            _arr = new int[capacity];
        }

        internal void Add(int item)
        {
            if (_count == _arr.Length)
            {
                int[] newArr = new int[_count == 0 ? 1: _count * 2];
                Console.WriteLine("new size: " + newArr.Length);
                CopyToNew(newArr, _arr);
                _arr = newArr;
            }
            _arr[_count++] = item;
        }

        private void CopyToNew(int[] n, int[] o)
        {
            for (int i = 0; i < o.Length; i++)
            {
                o[i] = n[i];
            }
        }

        internal void Remove(int i)
        {
            if (i < 0 || i > _count)
            {
                throw new ArgumentException($"{i} is out of bounds");
            }

            int item = _arr[i];
            while (i < _count - 1)
            {
                _arr[i] = _arr[i + 1];
                i++;

            }
        }

        internal int Count
        {
            get
            {
                return _count;
            }
        }
    }
}
