
namespace Caldast.AlgoLife
{
    using System;

    /// <summary>
    /// Arraylist implementation
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class MyArrayList<T>
    {
        private int _count = 0;
        private T[] _arr;
        private const int _factor = 2;

        /// <summary>
        /// Gets count of items in list
        /// </summary>
        public int Count => _count;

        /// <summary>
        /// Initializes new instance of <see cref="MyArrayList{T}"/>
        /// </summary>
        /// <param name="capacity">Capacity</param>
        public MyArrayList(int capacity = 0)
        {          
            _arr = new T[_count];            
        }

        /// <summary>
        /// Adds item at the end of the list
        /// </summary>
        /// <param name="item">Item to add</param>
        public void Add(T item)
        {      
            if (_count >= _arr.Length)
            {
                Increment();
            }
            _arr[_count++] = item;
        }

        /// <summary>
        /// Removes item from the list at specified index
        /// </summary>
        /// <param name="index">Index</param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            
            while (index < _count)
            {
                _arr[index] = _arr[index + 1];
                index++;
            }            
            _count--;
        }

        /// <summary>
        /// Removes item from list
        /// </summary>
        /// <param name="item">Item to remove</param>
        public void Remove(T item)
        {
            int index = Find(item);
            if (index != -1)
            {
                RemoveAt(index);
            }
        }

        /// <summary>
        /// Finds index of an item if present, otherwise returns -1
        /// </summary>
        /// <param name="item">Item whose index is to be found</param>
        /// <returns>Index</returns>
        public int Find(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_arr[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Returns item at specified index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Item</returns>
        public T FindAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return _arr[index];
        }      

        /// <summary>
        /// Increments array by a factor
        /// </summary>
        private void Increment()
        {
            int newCount = _count == 0 ? 1 : _count * _factor;
            T[] newArr = new T[newCount];
            Array.Copy(_arr,newArr,_count);            
            _arr = newArr;
        }
    }
}
