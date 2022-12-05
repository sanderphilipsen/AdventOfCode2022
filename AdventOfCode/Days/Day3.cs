namespace AdventOfCode.Days
{
    internal class Day3 : BaseDay
    {
        public Day3() : base(3, true)
        {
        }

        protected override void ExecuteDay(string[] lines, string[]? linesForB = null)
        {
            GetResult1(lines);
            if (linesForB is not null)
                GetResult2(linesForB);
            PrintResults();
        }

        private void GetResult1(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                var length = line.Length;
                var firstPart = line[..(length / 2)];
                var secondPart = line.Substring(length / 2, length / 2);

                List<char> firstCompartment = new(firstPart);
                List<char> secondCompartment = new(secondPart);
                var commonLetter = firstCompartment.Intersect(secondCompartment).First();
                FirstStarResult += GetLetterValue(commonLetter);
            }
        }

        private void GetResult2(string[] lines)
        {
            for (var i = 0; i < lines.Length; i += 3)
            {
                var firstList = new List<char>(lines[i]);
                var secondList = new List<char>(lines[i + 1]);
                var thirdList = new List<char>(lines[i + 2]);
                var commonLetter = firstList.Intersect(secondList).Intersect(thirdList).First();
                SecondStarResult += GetLetterValue(commonLetter);
            }
        }

        private static int GetLetterValue(char letter)
        => char.IsUpper(letter) ? (char.ToUpper(letter) - 64) + 26 : (char.ToUpper(letter) - 64);
    }
}