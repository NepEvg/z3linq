using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace z3linq
{
    class Program
    {

        static void Main(string[] args)
        {
            int count = 0;
            StreamReader sr = new StreamReader("file.txt");
            List<Pepl> people = new List<Pepl>();
            while (!sr.EndOfStream)
            {
                string str = sr.ReadLine();
                string[] st = str.Split(' ');
                people.Add(new Pepl() { f = st[0], i = st[1], o = st[2], group = st[3], mark = Convert.ToDouble(st[4]) });
                count++;
            }
            sr.Close();
            try
            {
                while (true)
                {
                    Console.Write("вывести максимальный[1], средний[2] или миниамльный[3] балл? ");
                    int ans = int.Parse(Console.ReadLine());
                    if (ans == 1)
                    {
                        Console.WriteLine("максимальный балл:");
                        double m = people.Max(a => a.mark);
                        foreach (var item in people)
                        {
                            if (item.mark == m)
                            {
                                Console.WriteLine(item.f + " " + item.i + " " + item.o + " " + item.group + " " + item.mark);
                            }
                        }
                    }
                    else if (ans == 2)
                    {
                        Console.WriteLine("средний балл:");
                        double m = people.Average(a => a.mark);
                        Console.WriteLine(m);
                    }
                    else if (ans == 3)
                    {
                        Console.WriteLine("минимальный балл:");
                        double m = people.Min(a => a.mark);
                        foreach (var item in people)
                        {
                            if (item.mark == m)
                            {
                                Console.WriteLine(item.f + " " + item.i + " " + item.o + " " + item.group + " " + item.mark);
                            }
                        }
                    }
                    Console.Write("сортировка по убыванию[1] или возрастанию[2]? ");
                    ans = int.Parse(Console.ReadLine());
                    if (ans == 1)
                    {
                        StreamWriter sw = new StreamWriter("file1.txt");
                        Console.WriteLine("сортировка по убыванию:");
                        foreach (var item in people.OrderByDescending(d => Convert.ToDouble(d.mark)))
                        {
                            Console.WriteLine($"{item.f} {item.i} {item.i} {item.group} {item.mark}");
                            sw.WriteLine($"{item.f} {item.i} {item.i} {item.group} {item.mark}");
                        }
                        sw.Close();
                        Console.WriteLine("---записано в файл---");
                    }
                    else if (ans == 2)
                    {
                        StreamWriter sw = new StreamWriter("file1.txt");
                        Console.WriteLine("сортировка по возрастанию:");
                        foreach (var item in people.OrderBy(d => Convert.ToDouble(d.mark)))
                        {
                            Console.WriteLine($"{item.f} {item.i} {item.o} {item.group} {item.mark}");
                            sw.WriteLine($"{item.f} {item.i} {item.i} {item.group} {item.mark}");
                        }
                        sw.Close();
                        Console.WriteLine("---записано в файл---");
                    }
                    Console.Write("выйти[1]? ");
                    ans = int.Parse(Console.ReadLine());
                    if (ans == 1)
                    {
                        break;
                    }
                }
            }
            catch { Console.Write("неверные данные"); }
        }
    }
}
