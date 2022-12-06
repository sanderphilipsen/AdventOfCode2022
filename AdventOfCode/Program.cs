using AdventOfCode;
using AdventOfCode.Days;

Console.Title = "Advent Of Code - Sander";
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("-------------------------------------------------");
Console.WriteLine("                ADVENT OF CODE");
Console.WriteLine("-------------------------------------------------");
Console.ResetColor();
var key = "";
do
{
    Console.Write("Enter the days you want to execute: ");
    var input = Console.ReadLine();
    var days = new List<BaseDay>();
    foreach (var dayInput in input)
    {
        var legalInput = int.TryParse(dayInput.ToString(), out var enteredDay);
        if (!legalInput)
            Console.WriteLine("Invalid input");

        days.Add(DayHelper.GetDayClass(enteredDay));
    }

    foreach (var day in days)
        day.Execute();


    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("-------------------------------------------------");

    Console.Write("Press any key to continue, c to clear, q to exit ");
    key = Console.ReadKey().Key.ToString();
    Console.WriteLine();

    if (key.ToLower() is "c")
        Console.Clear();

} while (key.ToLower() != "q");



