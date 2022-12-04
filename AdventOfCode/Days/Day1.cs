namespace AdventOfCode.Days
{
    internal class Day1 : BaseDay
    {
        internal Day1() : base(1)
        {

        }

        protected override void ExecuteDay()
        {
            string[] lines = Helpers.ReadInput(1);
            var firstStar = GetElvesResults(lines).First();
            Console.WriteLine(firstStar);
            var secondStar = GetElvesResults(lines).Take(3).Sum(x => x);
            Console.WriteLine(secondStar);
        }

        private static List<int> GetElvesResults(string[] lines)
        {
            List<int> results = new List<int>();
            int elfResult = 0;

            foreach (string line in lines)
            {
                var isValue = int.TryParse(line, out var result);
                if (isValue)
                    elfResult += result;
                if (!isValue)
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
