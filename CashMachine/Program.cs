using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, int> b = new Dictionary<int, int> { { 500, 5 }, { 100, 10 }, { 50, 5 }, { 10, 5 } };
        PrintBanknotes(b);
        Console.Write("Введите сумму: ");
        int s = Convert.ToInt32(Console.ReadLine()), r;
        Dictionary<int, int> o = new Dictionary<int, int>();
        foreach (KeyValuePair<int, int> p in b)
        {
            r = s / p.Key;
            if (r > p.Value) r = p.Value;
            s -= r * p.Key;
            o.Add(p.Key, r);
            if (s == 0) break;
        }
        if (s != 0)
        {
            Console.WriteLine("Невозможно выдать сумму!");
            return;
        }
        Console.WriteLine("Выданные купюры:");
        foreach (KeyValuePair<int, int> p in o) Console.WriteLine(p.Key + ": " + p.Value);
    }

    static void PrintBanknotes(Dictionary<int, int> banknotes)
    {
        Console.WriteLine("Купюры:");
        foreach (KeyValuePair<int, int> p in banknotes) Console.WriteLine(p.Key + ": " + p.Value);
    }
}