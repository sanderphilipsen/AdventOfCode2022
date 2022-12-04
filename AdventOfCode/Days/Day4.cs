namespace AdventOfCode.Days
{
    internal class Day4 : BaseDay
    {
        public Day4() : base("Day 4")
        {

        }

        protected override void ExecuteDay()
        {
            var lines = Helpers.ReadInput(4);
            var firstStarResult = 0;
            var secondStarResult = 0;
            foreach (var line in lines)
            {
                var ranges = line.Split(',');
                var firstRange = ranges[0].Split('-');
                var firstRangeStart = int.Parse(firstRange[0]);
                var firstRangeEnd = int.Parse(firstRange[1]);
                var secondRange = ranges[1].Split('-');
                var secondRangeEnd = int.Parse(secondRange[1]);
                var secondRangeStart = int.Parse(secondRange[0]);
                var overlappingFull = OverLapsFull(firstRangeStart, firstRangeEnd, secondRangeStart, secondRangeEnd);
                var overlapping = OverLaps(firstRangeStart, firstRangeEnd, secondRangeStart, secondRangeEnd);

                if (overlappingFull)
                    firstStarResult++;

                if (overlapping)
                    secondStarResult++;
            }
            Console.WriteLine(firstStarResult);
            Console.WriteLine(secondStarResult);
        }

        private bool OverLapsFull(int start1, int end1, int start2, int end2)
        {
            if (start1 >= start2 && end1 <= end2)
                return true;
            if (start2 >= start1 && end2 <= end1)
                return true;
            return false;
        }

        private bool OverLaps(int start1, int end1, int start2, int end2)
        {
            return (Math.Max(0, Math.Min(end1, end2) - Math.Max(start1, start2) + 1)) > 0;
        }
    }
}
