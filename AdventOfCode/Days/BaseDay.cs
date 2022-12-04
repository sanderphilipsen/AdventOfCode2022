using System.Diagnostics;

namespace AdventOfCode.Days
{
    public abstract class BaseDay
    {
        public string Name { get; set; }
        public Stopwatch StopWatch;
        protected abstract void ExecuteDay();

        public void Execute()
        {
            StopWatch.Start();
            ExecuteDay();
            StopWatch.Stop();
            Console.WriteLine($"Elapsed time: {StopWatch.ElapsedTicks} ticks");
            StopWatch.Reset();
        }

        public BaseDay(string name)
        {
            StopWatch = new Stopwatch();
            Name = name;
        }
    }
}
