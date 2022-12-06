namespace AdventOfCode.Days
{
    internal class Day6 : BaseDay
    {
        public Day6() : base(6, false)
        {

        }

        protected override void ExecuteDay(string[] lines, string[]? linesForB = null)
        {
            FirstStarResult = ExecuteStar(lines[0].ToCharArray(), 4);
            SecondStarResult = ExecuteStar(lines[0].ToCharArray(), 14);
            PrintResults();
        }

        private int ExecuteStar(IReadOnlyList<char> chars, int numberOfUniques)
        {
            for (var i = 0; i < chars.Count; i++)
            {
                if (chars.Skip(i).Take(numberOfUniques).Distinct().Count() != numberOfUniques)
                    continue;
                return i + numberOfUniques;
            }
            return 0;
        }
    }
}
