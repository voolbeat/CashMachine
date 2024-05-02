using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, int> b = new Dictionary<int, int> { { 500, 5 }, { 100, 10 }, { 50, 5 }, { 10, 5 } };
        PrintBanknotes(b);
        Console.Write("Введите сумму: ");
        int s = Convert.ToInt32(Console.ReadLine());
        Dictionary<int, int> o = CalculateNotes(b, s);
        if (o == null)
        {
            Console.WriteLine("Невозможно выдать сумму!");
            return;
        }
        PrintIssuedNotes(o);
    }

    static void PrintBanknotes(Dictionary<int, int> banknotes)
    {
        Console.WriteLine("Купюры:");
        foreach (KeyValuePair<int, int> p in banknotes) Console.WriteLine(p.Key + ": " + p.Value);
    }

    static Dictionary<int, int> CalculateNotes(Dictionary<int, int> banknotes, int amount)
    {
        Dictionary<int, int> issuedNotes = new Dictionary<int, int>();
        foreach (KeyValuePair<int, int> p in banknotes)
        {
            int count = amount / p.Key;
            if (count > p.Value) count = p.Value;
            amount -= count * p.Key;
            issuedNotes.Add(p.Key, count);
            if (amount == 0) break;
        }
        return amount == 0 ? issuedNotes : null;
    }

    static void PrintIssuedNotes(Dictionary<int, int> issuedNotes)
    {
        Console.WriteLine("Выданные купюры:");
        foreach (KeyValuePair<int, int> p in issuedNotes) Console.WriteLine(p.Key + ": " + p.Value);
    }
}