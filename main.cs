using System;
using System.Collections.Generic;

enum Category { Ēdiens, Transports, Izklaide, Citi }

class Income
{
    public DateTime Date { get; set; }
    public string Source { get; set; }
    public decimal Amount { get; set; }
    public override string ToString() => $"{Date:yyyy-MM-dd} {Source} {Amount}€";
}

class Expense
{
    public DateTime Date { get; set; }
    public Category Category { get; set; }
    public decimal Amount { get; set; }
    public string Note { get; set; }
    public override string ToString() => $"{Date:yyyy-MM-dd} {Category} {Amount}€ {Note}";
}

class Subscription
{
    public string Name { get; set; }
    public decimal MonthlyPrice { get; set; }
    public bool IsActive { get; set; }
    public override string ToString() => $"{Name} {MonthlyPrice}€ Aktīvs: {IsActive}";
}

class Program
{
    static List<Income> incomes = new();
    static List<Expense> expenses = new();
    static List<Subscription> subs = new();

    static void Main()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("1. Pievienot ienākumu");
            Console.WriteLine("2. Pievienot izdevumu");
            Console.WriteLine("3. Pievienot abonementu");
			Console.WriteLine("4. Saraksti(X)");
			Console.WriteLine("5. Filtri(X)");
            Console.WriteLine("6. Pārskats");
            Console.WriteLine("0. Iziet");

            switch (Console.ReadLine())
            {
                case "1": AddIncome(); break;
                case "2": AddExpense(); break;
                case "3": AddSubscription(); break;
                case "6": ShowAll(); break;
                case "0": running = false; break;
                default: Console.WriteLine("Nederīga izvēle!"); break;
            }
        }
    }

    static void AddIncome()
    {
        Console.Write("Datums (YYYY-MM-DD): ");
        DateTime.TryParse(Console.ReadLine(), out var d);
        Console.Write("Avots: ");
        string s = Console.ReadLine();
        Console.Write("Summa: ");
        decimal.TryParse(Console.ReadLine(), out var a);
        incomes.Add(new Income { Date = d, Source = s, Amount = a });
    }

    static void AddExpense()
    {
        Console.Write("Datums (YYYY-MM-DD): ");
        DateTime.TryParse(Console.ReadLine(), out var d);
        Console.Write("Kategorija (0. Ēdiens, 1. Transports, 2. Izklaide, 4. Cits): ");
        int.TryParse(Console.ReadLine(), out var c);
        Console.Write("Summa: ");
        decimal.TryParse(Console.ReadLine(), out var a);
        Console.Write("Piezīme: ");
        string n = Console.ReadLine();
        expenses.Add(new Expense { Date = d, Category = (Category)c, Amount = a, Note = n });
    }

    static void AddSubscription()
    {
        Console.Write("Nosaukums: ");
        string n = Console.ReadLine();
        Console.Write("Cena: ");
        decimal.TryParse(Console.ReadLine(), out var p);
        subs.Add(new Subscription { Name = n, MonthlyPrice = p, IsActive = true });
    }

    static void ShowAll()
    {
        Console.WriteLine("Ienākumi");
        foreach (var i in incomes) Console.WriteLine(i);
        Console.WriteLine("Izdevumi");
        foreach (var e in expenses) Console.WriteLine(e);
        Console.WriteLine("Abonementi");
        foreach (var s in subs) Console.WriteLine(s);
    }
}
