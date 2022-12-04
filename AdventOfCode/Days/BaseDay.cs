using System.Diagnostics;

namespace AdventOfCode.Days
{
    public abstract class BaseDay
    {
        private int Day { get; set; }
        private Stopwatch StopWatch;
        protected abstract void ExecuteDay();

        internal void Execute()
        {
            Console.WriteLine($"Day{Day}:");
            StopWatch.Start();
            ExecuteDay();
            StopWatch.Stop();
            Console.WriteLine($"Elapsed time: {StopWatch.ElapsedTicks} ticks");
            StopWatch.Reset();
            Console.WriteLine("---------------------------------------------");
        }

        protected BaseDay(int day)
        {
            StopWatch = new Stopwatch();
            Day = day;
        }
    }
}
