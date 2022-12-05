using AdventOfCode.Days;

var days = new List<BaseDay>
{
    new Day5(),

};

foreach (var day in days)
    day.Execute();

Console.WriteLine();
Console.WriteLine();
Console.WriteLine("----------------------------------------");

Console.WriteLine("Press any key to exit.");
Console.ReadKey();

