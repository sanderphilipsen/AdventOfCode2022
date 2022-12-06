namespace AdventOfCode.Days
{
    internal class Day6 : BaseDay
    {
        public Day6() : base(6, false)
        {

        }

        protected override void ExecuteDay(string[] lines, string[]? linesForB = null)
        {
            ExecuteStar(lines, 4);
            ExecuteStar(lines, 14);
            PrintResults();
        }

        private void ExecuteStar(string[] lines, int numberOfUniques)
        {
            var chars = lines[0].ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                var list = new List<char>();
                for (int x = 0; x < numberOfUniques; x++)
                {
                    list.Add(chars[i + x]);
                }
                if (list.Distinct().Count() == numberOfUniques)
                {
                    if (numberOfUniques == 14)
                        SecondStarResult = i + numberOfUniques;
                    if (numberOfUniques == 4)
                        FirstStarResult = i + numberOfUniques;
                    break;
                }
            }
        }
    }
}
