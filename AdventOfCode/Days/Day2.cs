namespace AdventOfCode.Days
{
    internal class Day2 : BaseDay
    {
        private static readonly string[] HisPlays = { "A", "B", "C" };
        private static readonly string[] ExpectedResultOrMyPlays = { "X", "Y", "Z" };
        private static readonly int[,] Points4GivenOpponentPlayAndResult = { { 3, 4, 8 }, { 1, 5, 9 }, { 2, 6, 7 } };
        private static readonly int[,] Points4GivenOpponentPlayAndMyPlays = { { 4, 8, 3 }, { 1, 5, 9 }, { 7, 2, 6 } };

        internal Day2() : base(2, false)
        {
        }

        protected override void ExecuteDay(string[] lines, string[]? linesForB = null)
        {
            FirstStarResult = GetMyResult(lines, Points4GivenOpponentPlayAndResult);
            SecondStarResult = GetMyResult(lines, Points4GivenOpponentPlayAndMyPlays);
            PrintResults();
        }

        private static int GetMyResult(IEnumerable<string> lines, int[,] matrix)
            => lines.Sum(x =>
            {
                var input = x.Split(' ');
                return matrix[HisPlays.FindIndex(input[0]), ExpectedResultOrMyPlays.FindIndex(input[1])];
            });
    }
}
