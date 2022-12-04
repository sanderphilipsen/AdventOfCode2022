namespace AdventOfCode.Days
{
    internal class Day2 : BaseDay
    {
        private static readonly string[] HisPlays = { "A", "B", "C" };
        private static readonly string[] ExpectedResultOrMyPlays = { "X", "Y", "Z" };
        private static readonly int[,] Points4GivenOpponentPlayAndResult = { { 3, 4, 8 }, { 1, 5, 9 }, { 2, 6, 7 } };
        private static readonly int[,] Points4GivenOpponentPlayAndMyPlays = { { 4, 8, 3 }, { 1, 5, 9 }, { 7, 2, 6 } };

        public Day2() : base("Day 2")
        {
        }

        protected override void ExecuteDay()
        {
            var lines = Helpers.ReadInput(2);
            var firstStar = GetMyResult(lines, Points4GivenOpponentPlayAndResult);
            Console.WriteLine(firstStar);
            var secondStar = GetMyResult(lines, Points4GivenOpponentPlayAndMyPlays);
            Console.WriteLine(secondStar);
        }

        private static int GetMyResult(string[] lines, int[,] matrix)
        {
            return lines.Sum(x =>
            {
                var input = x.Split(' ');
                return matrix[HisPlays.FindIndex(input[0]), ExpectedResultOrMyPlays.FindIndex(input[1])];
            });
        }
    }
}
