namespace AdventOfCode.Days
{
    internal class Day4 : BaseDay
    {
        internal Day4() : base(4, false)
        {

        }

        protected override void ExecuteDay(string[] lines, string[]? linesForB = null)
        {
            foreach (var line in lines)
            {
                var ranges = line.Split(',');
                var firstRange = ranges[0].Split('-');
                var secondRange = ranges[1].Split('-');
                CheckLine(int.Parse(firstRange[0]), int.Parse(firstRange[1]),
                    int.Parse(secondRange[0]), int.Parse(secondRange[1]));
            }
            PrintResults();
        }
        private void CheckLine(int firstRangeStart, int firstRangeEnd, int secondRangeStart, int secondRangeEnd)
        {
            if (OverLapsFull(firstRangeStart, firstRangeEnd, secondRangeStart, secondRangeEnd))
                FirstStarResult++;

            if (OverLaps(firstRangeStart, firstRangeEnd, secondRangeStart, secondRangeEnd))
                SecondStarResult++;
        }

        private static bool OverLapsFull(int start1, int end1, int start2, int end2)
            => (start1 >= start2 && end1 <= end2) || (start2 >= start1 && end2 <= end1);

        private static bool OverLaps(int start1, int end1, int start2, int end2)
            => (Math.Max(0, Math.Min(end1, end2) - Math.Max(start1, start2) + 1)) > 0;
    }
}
