using System;
using System.IO;
using System.Linq;
using System.Text;

namespace List
{
    class Program
    {
        static List<Minion> minions = new();

        static void Main(string[] args)
        {
            string path = args[0];

            StreamReader sr = new StreamReader(path, System.Text.Encoding.Default);
            StringBuilder sb = new StringBuilder();
            sb.Append(sr.ReadToEnd());
            sr.Close();

            List<string> inputs = new List<string>();
            foreach (var s in sb.ToString().Split("\n")) inputs.Add(s);

            for (int i = 0; i <= inputs.Count - 1; i++)
            {
                string name = inputs[i].Split(" ")[0];
                int age = int.Parse(inputs[i].Split(" ")[1]);

                Minion minion = new Minion(name, age);
                minions.Add(minion);
            }

            Console.WriteLine("Миньоны до:");
            foreach (var m in minions)
            {
                Console.WriteLine(m.ToString());
            }
            Console.Write("Введите число, на сколько лет повзрослеют миньоны: ");
            int n = int.Parse(Console.ReadLine()); 
            
            Console.WriteLine("Миньоны после:");
            foreach (var m in minions)
            {
                m.Age += n;
                Console.WriteLine(m.ToString());
            }

            StreamWriter sw = new StreamWriter(path);

            sb.Clear();
            for (int i = 0; i < minions.Count; i++)
            {
                if (i == minions.Count - 1)
                {
                    sb.Append($"{minions[i].Name} {minions[i].Age}");
                    continue;
                }

                sb.Append($"{minions[i].Name} {minions[i].Age}\n");
            }

            //sb.Replace("\r", "");
            sw.Write(sb.ToString());
            sw.Close();
            Console.WriteLine("Нажмите любую клавишу для завершения...");
            Console.ReadKey();
            
        }
    }
}