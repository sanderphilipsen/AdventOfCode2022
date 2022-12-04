using AdventOfCode.Days;

var days = new List<BaseDay>
{
    new Day1(),
    new Day2(),
    new Day3(),
    new Day4()
};

foreach (var day in days)
    day.Execute();

Console.WriteLine("Press any key to exit.");
Console.ReadKey();

