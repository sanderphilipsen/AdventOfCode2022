namespace AdventOfCode.Days
{
    internal class Day3 : BaseDay
    {
        public Day3() : base("Day 3")
        {
        }

        protected override void ExecuteDay()
        {
            GetResult1();
            GetResult2();
        }

        private void GetResult1()
        {
            var lines = Helpers.ReadInput(3);
            var result = 0;
            foreach (var line in lines)
            {
                var length = line.Length;
                var firstPart = line.Substring(0, length / 2);
                var secondPart = line.Substring(length / 2, length / 2);

                List<char> firstCompartment = new(firstPart);
                List<char> secondCompartment = new(secondPart);
                var commonLetter = firstCompartment.Intersect(secondCompartment).First();
                result += GetLetterValue(commonLetter);
            }
            Console.WriteLine(result);
        }

        private void GetResult2()
        {
            var lines = Helpers.ReadInput(3, true);
            var result = 0;
            for (int i = 0; i < lines.Length; i = i + 3)
            {
                var firstList = new List<char>(lines[i]);
                var secondList = new List<char>(lines[i + 1]);
                var thirdList = new List<char>(lines[i + 2]);
                var commonLetter = firstList.Intersect(secondList).Intersect(thirdList).First();
                result += GetLetterValue(commonLetter);
            }
            Console.WriteLine(result);
        }

        private int GetLetterValue(char letter)
        {
            var index = char.ToUpper(letter) - 64;
            return Char.IsUpper(letter) ? index + 26 : index;
        }
    }
}