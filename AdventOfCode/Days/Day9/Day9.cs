namespace AdventOfCode.Days.Day9
{
    internal class Day9 : BaseDay
    {
        private readonly Position _headPosition;
        private readonly Position[] _tails = new Position[9];
        private readonly List<Position> _visitedLastTailPositions;
        private readonly List<Position> _visitedFirstTailPositions;

        public Day9() : base(9, false)
        {
            _headPosition = new Position(0, 0);

            for (var x = 0; x < 9; x++)
            {
                _tails[x] = new Position(0, 0);
            }
            _visitedLastTailPositions = new List<Position>
            {
               new Position(0,0)
            };
            _visitedFirstTailPositions = new List<Position>
            {
                new Position(0,0)
            };
        }

        protected override void ExecuteDay(string[] lines, string[]? linesForB = null)
        {
            foreach (var line in lines)
            {
                var input = line.Split(' ');
                var direction = input[0];
                var steps = int.Parse(input[1]);
                MoveHead(direction, steps);

            }

            FirstStarResult = _visitedFirstTailPositions.Count();
            SecondStarResult = _visitedLastTailPositions.Count();

            PrintResults();
        }

        private void MoveHead(string direction, int steps)
        {
            for (var i = 0; i < steps; i++)
            {
                switch (direction)
                {
                    case "U":
                        _headPosition.MoveUp();
                        break;
                    case "L":
                        _headPosition.MoveLeft();
                        break;
                    case "R":
                        _headPosition.MoveRight();
                        break;
                    case "D":
                        _headPosition.MoveDown();
                        break;
                    default:
                        break;
                }

                for (int j = 0; j < _tails.Length; j++)
                {
                    var head = j == 0 ? _headPosition : _tails[j - 1];
                    var tail = _tails[j];

                    if (ShouldTailMove(tail, head))
                    {
                        _tails[j] = LetTailFollowHead(head, tail);

                        if (j == 0)
                            UpdateVisitedFirstTailList(_tails[j]);
                        if (j == 8)
                            UpdateVisitedLastTailList(_tails[j]);
                    }
                    else
                    {
                        break;
                    }

                }
            }
        }
        private void UpdateVisitedFirstTailList(Position pos)
        {
            var res = _visitedFirstTailPositions.FirstOrDefault(p => p.X == pos.X && p.Y == pos.Y);
            if (res is null)
                _visitedFirstTailPositions.Add(new Position(pos.X, pos.Y));
        }

        private void UpdateVisitedLastTailList(Position pos)
        {
            var res = _visitedLastTailPositions.FirstOrDefault(p => p.X == pos.X && p.Y == pos.Y);
            if (res is null)
                _visitedLastTailPositions.Add(new Position(pos.X, pos.Y));
        }

        private bool ShouldTailMove(Position tail, Position head)
        {
            if (tail.X == head.X && tail.Y == head.Y)
                return false;
            if (tail.X == head.X + 1 && tail.Y == head.Y)
                return false;
            if (tail.X == head.X - 1 && tail.Y == head.Y)
                return false;
            if (tail.X == head.X && tail.Y == head.Y + 1)
                return false;
            if (tail.X == head.X && tail.Y == head.Y - 1)
                return false;
            if (tail.X == head.X - 1 && tail.Y == head.Y - 1)
                return false;
            if (tail.X == head.X + 1 && tail.Y == head.Y + 1)
                return false;
            if (tail.X == head.X - 1 && tail.Y == head.Y + 1)
                return false;
            if (tail.X == head.X + 1 && tail.Y == head.Y - 1)
                return false;

            return true;
        }

        private Position LetTailFollowHead(Position head, Position tail)
        {
            var xDiff = head.X - tail.X;
            var yDiff = head.Y - tail.Y;

            if ((xDiff > 1 && yDiff == 1))
            {
                tail.MoveRight();
                tail.MoveUp();
            }
            else if ((xDiff > 1 && yDiff == -1))
            {
                tail.MoveRight();
                tail.MoveDown();
            }
            else if (xDiff < -1 && yDiff == 1)
            {
                tail.MoveLeft();
                tail.MoveUp();
            }
            else if (xDiff < -1 && yDiff == -1)
            {
                tail.MoveLeft();
                tail.MoveDown();
            }
            else if (yDiff > 1 && xDiff == 1)
            {
                tail.MoveRight();
                tail.MoveUp();
            }
            else if (yDiff < -1 && xDiff == 1)
            {
                tail.MoveRight();
                tail.MoveDown();
            }
            else if (yDiff > 1 && xDiff == -1)
            {
                tail.MoveLeft();
                tail.MoveUp();
            }
            else if (yDiff < 1 && xDiff == -1)
            {
                tail.MoveLeft();
                tail.MoveDown();
            }
            else if (yDiff > 1)
            {
                tail.MoveUp();
            }
            else if (yDiff < -1)
            {
                tail.MoveDown();
            }
            else if (xDiff < -1)
            {
                tail.MoveLeft();
            }
            else if (xDiff > 1)
            {
                tail.MoveRight();
            }
            return tail;
        }
    }
}
