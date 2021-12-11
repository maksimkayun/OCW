using System;

namespace List
{
    public class Hub<T>
    {
        public T Value { get; set; }
        public Hub<T> Next { get; set; }
        public Hub<T> Previous { get; set; }

        public Hub(T value)
        {
            Value = value;
        }
    }
}