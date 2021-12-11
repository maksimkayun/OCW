using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace List
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] _items;
        public int Count { get; protected set; }
        public int Capacity { get; protected set; } 
        private const int _defaultCapacity = 5;

        public Stack()
        {
            Capacity = _defaultCapacity;
            _items = new T[Capacity];
            Count = 0;
        }

        public Stack(int length)
        {
            if (length > 0)
            {
                _items = new T[length];
                Capacity = length;
                Count = 0;
            }
            else
            {
                throw new InvalidEnumArgumentException($"length = '{length}' is not correct argument");
            }
            
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void Add(T item)
        {
            if (Count == _items.Length)
            {
                T[] temp = _items;
                Capacity = _items.Length * 2;
                _items = new T[Capacity];
                for (int i = 0; i < Count; i++)
                {
                    _items[i] = temp[i];
                }

                _items[Count++] = item;
            }
            else
            {
                _items[Count++] = item;
            }
        }

        public T this[int index]
        {
            get => _items[index];
            set => _items[index] = value;
        }

        public T Remove()
        {
            T removed = default(T);
            if (!IsEmpty())
            {
                removed = _items[Count];
                Count--;
            }
            return removed;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int index = Count - 1;
            T current = default(T);
            while (index > -1)
            {
                current = _items[index];
                index--;
                yield return current;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}