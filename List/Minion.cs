using System;

namespace List
{
    public class Minion : IComparable<Minion>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Minion(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public int CompareTo(Minion? other)
        {
            if (Name.Equals(other?.Name) && Age == other?.Age)
            {
                return 0;
            }
            else if (Age < other?.Age)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public override string ToString()
        {
            return $"{Name} возраст: {Age}";
        }
    }
}