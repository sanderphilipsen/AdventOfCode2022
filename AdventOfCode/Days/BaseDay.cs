using System.Diagnostics;

namespace AdventOfCode.Days
{
    public abstract class BaseDay
    {
        private readonly int _day;
        private readonly Stopwatch _stopWatch;
        protected abstract void ExecuteDay();

        internal void Execute()
        {
            Console.WriteLine($"Day{_day}:");
            _stopWatch.Start();
            ExecuteDay();
            _stopWatch.Stop();
            Console.WriteLine($"Elapsed time: {_stopWatch.ElapsedTicks} ticks");
            _stopWatch.Reset();
            Console.WriteLine("---------------------------------------------");
        }

        protected BaseDay(int day)
        {
            _stopWatch = new Stopwatch();
            _day = day;
        }
    }
}
