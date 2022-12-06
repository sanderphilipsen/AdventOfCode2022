using System.Diagnostics;

namespace AdventOfCode.Days
{
    public abstract class BaseDay
    {
        private readonly int _day;
        private readonly Stopwatch _stopWatch;
        private readonly bool _hasBInput;

        protected int FirstStarResult = 0;
        protected int SecondStarResult = 0;

        protected string FirstStarResultAsString = "";
        protected string SecondStarResultAsString = "";

        protected abstract void ExecuteDay(string[] lines, string[]? linesForB = null);

        protected BaseDay(int day, bool hasBInput)
        {
            _stopWatch = new Stopwatch();
            _hasBInput = hasBInput;
            _day = day;
        }

        internal void Execute()
        {
            PrintDayLabel();

            _stopWatch.Start();

            ExecuteDay(Helpers.ReadInput(_day), _hasBInput ? Helpers.ReadInput(_day, true) : null);

            StopTimerPrintElapsedTicksAndResetTimer();

        }

        protected void PrintResults()
        {

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("             * ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{FirstStarResult}");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"            ** ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{SecondStarResult}");
            Console.WriteLine();

            Console.ResetColor();
        }

        protected void PrintStringResults()
        {

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("             * ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{FirstStarResultAsString}");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"            ** ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{SecondStarResultAsString}");
            Console.WriteLine();

            Console.ResetColor();
        }

        private void StopTimerPrintElapsedTicksAndResetTimer()
        {
            _stopWatch.Stop();
            Console.WriteLine();

            Console.WriteLine($"            Elapsed time: {_stopWatch.ElapsedTicks} ticks");

            _stopWatch.Reset();
        }


        private void PrintDayLabel()
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"                    DAY {_day}");
            Console.WriteLine("-------------------------------------------------");

            Console.WriteLine();

            Console.ResetColor();
        }
    }
}
