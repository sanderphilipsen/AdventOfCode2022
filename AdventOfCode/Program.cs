using AdventOfCode.Days;

var days = new List<BaseDay>
{
    new Day1(),
    new Day2(),
    new Day3(),
    new Day4()
};

foreach (var day in days)
{
    Console.WriteLine($"{day.Name}:");

    day.Execute();
    Console.WriteLine("---------------------");
}

Console.WriteLine("Press any key to exit.");
Console.ReadKey();

