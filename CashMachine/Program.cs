using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, int> banknotes = new Dictionary<int, int> { { 500, 5 }, { 100, 10 }, { 50, 5 }, { 10, 5 } };
        PrintBanknotes(banknotes);
        int amount = ReadAmountFromUser();
        Dictionary<int, int> issuedNotes = CalculateIssuedNotes(banknotes, amount);
        PrintIssuedNotes(issuedNotes);
    }

    static void PrintBanknotes(Dictionary<int, int> banknotes)
    {
        Console.WriteLine("Купюры:");
        foreach (KeyValuePair<int, int> note in banknotes)
        {
            Console.WriteLine($"{note.Key}: {note.Value}");
        }
    }

    static int ReadAmountFromUser()
    {
        int amount;
        do
        {
            Console.Write("Введите сумму: ");
        } while (!int.TryParse(Console.ReadLine(), out amount) || amount <= 0);
        return amount;
    }

    static Dictionary<int, int> CalculateIssuedNotes(Dictionary<int, int> banknotes, int amount)
    {
        Dictionary<int, int> issuedNotes = new Dictionary<int, int>();
        foreach (KeyValuePair<int, int> note in banknotes)
        {
            int count = amount / note.Key;
            if (count > note.Value)
            {
                count = note.Value;
            }
            amount -= count * note.Key;
            issuedNotes.Add(note.Key, count);
            if (amount == 0)
            {
                break;
            }
        }
        return amount == 0 ? issuedNotes : null;
    }

    static void PrintIssuedNotes(Dictionary<int, int> issuedNotes)
    {
        if (issuedNotes == null)
        {
            Console.WriteLine("Невозможно выдать сумму!");
            return;
        }
        Console.WriteLine("Выданные купюры:");
        foreach (KeyValuePair<int, int> note in issuedNotes)
        {
            Console.WriteLine($"{note.Key}: {note.Value}");
        }
    }
}