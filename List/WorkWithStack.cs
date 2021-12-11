using System;

namespace List
{
    public class WorkWithStack
    {
        public static void Work()
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < 11; i++)
            {
                int value = new Random().Next(1, 180);
                Console.Write(value + " ");
                stack.Add(value);
            }
            Console.WriteLine('\n');

            foreach (var elem in stack)
            {
                Console.Write($"{elem} ");
            }

            stack.Remove();
            Console.WriteLine('\n');

            foreach (var elem in stack)
            {
                Console.Write($"{elem} ");
            }
        }
    }
}