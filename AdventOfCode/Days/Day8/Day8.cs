namespace AdventOfCode.Days.Day8
{
    internal class Day8 : BaseDay
    {
        private int[,] _forest;
        private int _totalOnYAs;
        private int _totalOnXAs;
        public Day8() : base(8, false)
        {

        }

        protected override void ExecuteDay(string[] lines, string[]? linesForB = null)
        {
            ReadForest(lines);
            FindAllVisibleTrees();
            PrintResults();
        }

        private void ReadForest(IReadOnlyList<string> lines)
        {
            _totalOnYAs = lines.Count;
            _totalOnXAs = lines[0].ToCharArray().Length;
            _forest = new int[_totalOnYAs, _totalOnXAs];
            for (int i = 0; i < lines.Count; i++)
            {
                var arr = lines[i].ToCharArray();

                for (int j = 0; j < arr.Length; j++)
                {
                    _forest[i, j] = int.Parse(arr[j].ToString());
                }
            }
        }

        private void FindAllVisibleTrees()
        {
            for (int i = 0; i < _totalOnYAs; i++)
            {
                for (int j = 0; j < _totalOnXAs; j++)
                {
                    if (i == 0 || j == 0 || i == _totalOnYAs - 1 || j == _totalOnXAs - 1 || IsVisible(j, i))
                        FirstStarResult++;

                    GetDistanceViewScore(j, i);
                }
            }
        }

        private bool IsVisible(int x, int y)
        {
            var invisibleFromSidesCounter = 0;
            for (var i = 0; i < x; i++)
            {
                if (_forest[y, i] >= _forest[y, x])
                {
                    invisibleFromSidesCounter++;
                    break;
                }
            }
            for (var i = _totalOnXAs - 1; i > x; i--)
            {
                if (_forest[y, i] >= _forest[y, x])
                {
                    invisibleFromSidesCounter++;
                    break;
                }
            }

            for (var i = 0; i < y; i++)
            {
                if (_forest[i, x] >= _forest[y, x])
                {
                    invisibleFromSidesCounter++;
                    break;
                }
            }

            for (var i = _totalOnYAs - 1; i > y; i--)
            {
                if (_forest[i, x] >= _forest[y, x])
                {
                    invisibleFromSidesCounter++;
                    break;
                }
            }

            return invisibleFromSidesCounter != 4;
        }

        private void GetDistanceViewScore(int x, int y)
        {
            var distanceScore = 0;
            var leftScore = 0;
            var rightScore = 0;
            var upScore = 0;
            var downScore = 0;

            for (var i = x - 1; i >= 0; i--)
            {

                if (_forest[y, x] > _forest[y, i])
                    leftScore++;
                else
                {
                    leftScore++;
                    break;
                }
            }

            for (var i = x + 1; i < _totalOnXAs; i++)
            {
                if (_forest[y, x] > _forest[y, i])
                    rightScore++;
                else
                {
                    rightScore++;
                    break;
                }
            }

            for (var i = y - 1; i >= 0; i--)
            {
                if (_forest[y, x] > _forest[i, x])
                    upScore++;
                else
                {
                    upScore++;
                    break;
                }
            }

            for (var i = y + 1; i < _totalOnYAs; i++)
            {
                if (_forest[y, x] > _forest[i, x])
                    downScore++;
                else
                {
                    downScore++;
                    break;
                }
            }

            distanceScore = downScore * upScore * leftScore * rightScore;

            if (distanceScore > SecondStarResult)
                SecondStarResult = distanceScore;
        }
    }
}
