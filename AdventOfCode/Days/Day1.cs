namespace AdventOfCode.Days
{
    internal class Day1 : BaseDay
    {
        internal Day1() : base(1, false)
        {

        }

        protected override void ExecuteDay(string[] lines, string[]? linesForB = null)
        {
            FirstStarResult = GetElvesResults(lines).First();
            SecondStarResult = GetElvesResults(lines).Take(3).Sum(x => x);
            PrintResults();
        }

        private static IEnumerable<int> GetElvesResults(IEnumerable<string> lines)
        {
            var results = new List<int>();
            var elfResult = 0;

            foreach (var line in lines)
            {
                if (int.TryParse(line, out var result))
                    elfResult += result;
                else
                {
                    results.Add(elfResult);
                    elfResult = 0;
                }
            }

            results.Sort();
            results.Reverse();
            return results;
        }
    }
}
