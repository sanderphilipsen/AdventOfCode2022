namespace AdventOfCode.Days
{
    internal class Day5 : BaseDay
    {

        private Stack<char>[] stacks = new Stack<char>[9];


        internal Day5() : base(5, false)
        {
            InitStacks();
        }
        protected override void ExecuteDay(string[] lines, string[]? linesForB = null)
        {
            FirsStar(lines);
            InitStacks();
            SecondStar(lines);

        }
        private void FirsStar(string[] lines)
        {
            var resultString = "";
            foreach (var line in lines)
            {
                var lineInput = line.Split(' ');
                var numberOfMoves = int.Parse(lineInput[1]);

                for (var i = 0; i < numberOfMoves; i++)
                {
                    var took = stacks[int.Parse(lineInput[3]) - 1].Pop();
                    stacks[int.Parse(lineInput[5]) - 1].Push(took);
                }
            }
            for (var i = 0; i < stacks.Length; i++)
            {
                var took = stacks[i].Pop();
                resultString += took;
            }
            Console.WriteLine(resultString);
        }

        private void SecondStar(string[] lines)
        {
            var resultString = "";
            foreach (var line in lines)
            {
                var lineInput = line.Split(' ');
                var numberOfMoves = int.Parse(lineInput[1]);

                List<char> toAdd = new List<char>();
                for (var i = 0; i < numberOfMoves; i++)
                {
                    var took2 = stacks[int.Parse(lineInput[3]) - 1].Pop();
                    toAdd.Add(took2);
                }
                toAdd.Reverse();
                foreach (var add in toAdd)
                {
                    stacks[int.Parse(lineInput[5]) - 1].Push(add);
                }
                toAdd.Clear();
            }
            for (var i = 0; i < stacks.Length; i++)
            {
                var took = stacks[i].Pop();
                resultString += took;
            }
            Console.WriteLine(resultString);
        }

        private Stack<char> FillStack(params char[] letters)
        {
            var result = new Stack<char>();
            foreach (var letter in letters)
            {
                result.Push(letter);
            }

            return result;
        }

        private void InitStacks()
        {
            stacks[0] = FillStack('p', 'f', 'm', 'q', 'w', 'g', 'r', 't'); ;
            stacks[1] = FillStack('h', 'f', 'r');
            stacks[2] = FillStack('p', 'z', 'r', 'v', 'g', 'h', 's', 'd');
            stacks[3] = FillStack('q', 'h', 'p', 'b', 'f', 'w', 'g');
            stacks[4] = FillStack('p', 's', 'm', 'j', 'h');
            stacks[5] = FillStack('m', 'z', 't', 'h', 's', 'r', 'p', 'l');
            stacks[6] = FillStack('p', 't', 'h', 'n', 'm', 'l');
            stacks[7] = FillStack('f', 'd', 'q', 'r');
            stacks[8] = FillStack('d', 's', 'c', 'n', 'l', 'p', 'h');
        }
    }
}
