namespace AdventOfCode.Days
{
    internal class Day5 : BaseDay
    {
        private readonly Stack<char>[] _stacks = new Stack<char>[9];

        internal Day5() : base(5, false)
        {
            InitStack();
        }

        protected override void ExecuteDay(string[] lines, string[]? linesForB = null)
        {
            Execute(lines);
            InitStack();
            Execute(lines, false);
            PrintStringResults();
        }

        private void Execute(IEnumerable<string> lines, bool lifo = true)
        {
            foreach (var line in lines)
            {
                var lineInput = line.Split(' ');
                var numberOfMoves = int.Parse(lineInput[1]);

                if (!lifo)
                    ProcessKeepOrder(numberOfMoves, lineInput);
                else
                    ProcessLifo(numberOfMoves, lineInput);
            }
            FormResult(lifo);
        }

        private void FormResult(bool lifo = true)
        {
            var result = "";

            for (var i = 0; i < _stacks.Length; i++)
                result += _stacks[i].Pop();

            if (lifo)
                FirstStarResultAsString = result;
            else
                SecondStarResultAsString = result;
        }


        private void ProcessKeepOrder(int numberOfMoves, IReadOnlyList<string> lineInput)
        {
            var toAdd = new List<char>();

            for (var i = 0; i < numberOfMoves; i++)
                toAdd.Add(_stacks[int.Parse(lineInput[3]) - 1].Pop());

            toAdd.Reverse();

            foreach (var add in toAdd)
                _stacks[int.Parse(lineInput[5]) - 1].Push(add);
        }

        private void ProcessLifo(int numberOfMoves, IReadOnlyList<string> lineInput)
        {
            for (var i = 0; i < numberOfMoves; i++)
                _stacks[int.Parse(lineInput[5]) - 1].Push(_stacks[int.Parse(lineInput[3]) - 1].Pop());
        }

        private void InitStack()
        {
            _stacks[0] = FillStack('p', 'f', 'm', 'q', 'w', 'g', 'r', 't'); ;
            _stacks[1] = FillStack('h', 'f', 'r');
            _stacks[2] = FillStack('p', 'z', 'r', 'v', 'g', 'h', 's', 'd');
            _stacks[3] = FillStack('q', 'h', 'p', 'b', 'f', 'w', 'g');
            _stacks[4] = FillStack('p', 's', 'm', 'j', 'h');
            _stacks[5] = FillStack('m', 'z', 't', 'h', 's', 'r', 'p', 'l');
            _stacks[6] = FillStack('p', 't', 'h', 'n', 'm', 'l');
            _stacks[7] = FillStack('f', 'd', 'q', 'r');
            _stacks[8] = FillStack('d', 's', 'c', 'n', 'l', 'p', 'h');
        }

        private static Stack<char> FillStack(params char[] letters)
        {
            var result = new Stack<char>();
            foreach (var letter in letters)
                result.Push(letter);

            return result;
        }
    }
}
