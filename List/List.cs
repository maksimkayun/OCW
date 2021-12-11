using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

namespace List
{
    public class List<T> : IEnumerable<T>
    {
        private Hub<T> head;
        private Hub<T> tail;
        public int Count { get; protected set; }

        public bool IsEmpty() => Count == 0;
        
        public void Add(T value)
        {
            Hub<T> hub = new Hub<T>(value);

            if (head is null)
            {
                head = hub;
            }
            else
            {
                tail.Next = hub;
                hub.Previous = tail;
            }

            tail = hub;
            Count++;
        }

        public T this[int index]
        {
            get { return Get(index); }
            set
            {
                T input = value;
                Hub<T> current = head;
                int currentIndex = 0;
                while (currentIndex != index)
                {
                    current = current.Next;
                    currentIndex++;
                    if (current == null)
                    {
                        throw new IndexOutOfRangeException();
                    }
                }

                current.Value = input;
            }
        } 

        public T Get(int index)
        {
            Hub<T> current = head;
            int currentIndex = 0;
            while (currentIndex != index)
            {
                current = current.Next;
                currentIndex++;
                if (current == null)
                {
                    throw new IndexOutOfRangeException();
                }
            }

            return current.Value;
        }
        public void RemoveAt(int index)
        {
            Hub<T> current = head;
            int currentIndex = 0;
            while (currentIndex != index)
            {
                current = current.Next;
                currentIndex++;
                if (current == null)
                {
                    throw new IndexOutOfRangeException();
                }
            }

            if (current.Previous == null)
            {
                head = current.Next;
            }
            else if (current.Next == null)
            {
                current.Previous.Next = null;
                tail = current.Previous;
            }
            else
            {
                current.Previous.Next = current.Next;
                current.Next.Previous = current.Previous;
            }

            Count--;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Hub<T> current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) this).GetEnumerator();
        }

        public IEnumerable<T> BackEnumerator()
        {
            Hub<T> current = tail;
            while (current != null)
            {
                yield return current.Value;
                current = current.Previous;
            }
        }
    }
}