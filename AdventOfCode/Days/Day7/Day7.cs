namespace AdventOfCode.Days.Day7
{
    internal class Day7 : BaseDay
    {

        private Directory _currentDirectory;
        private readonly List<Directory> _directories;
        private const int Capacity = 70000000;
        private const int UpdateRequiredSpace = 30000000;
        private int _spaceToMakeFree = 0;

        public Day7() : base(7, false)
        {
            _currentDirectory = new Directory(null).SetName("root");
            _directories = new List<Directory> { _currentDirectory };
        }

        protected override void ExecuteDay(string[] lines, string[]? linesForB = null)
        {
            foreach (var line in lines)
            {
                var input = line.Split(" ");

                if (input[0] is "$")
                    ProcessCommand(input);
                else if (int.TryParse(input[0], out var size))
                    ProcessFile(size, input[1]);
                else if (input[0] is "dir")
                    ProcessDir(input[1]);
            }

            CalculateFirsStarResult();
            CalculateSecondStarResult();

            PrintResults();
        }

        private void CalculateFirsStarResult()
        {
            FirstStarResult = _directories.Sum(x =>
            {
                var dirSize = x.GetDirectorySize();
                return dirSize <= 100000 ? dirSize : 0;
            });

            _currentDirectory = _directories.Single(x => x.Name == "root");
            _spaceToMakeFree = (_currentDirectory.GetDirectorySize() + UpdateRequiredSpace) - Capacity;
        }

        private void CalculateSecondStarResult()
        {
            var bestSolution = Capacity;
            foreach (var directory in _directories)
            {
                var dirSize = directory.GetDirectorySize();
                var res = dirSize - _spaceToMakeFree;

                if (!(res >= 0 && res < bestSolution))
                    return;

                bestSolution = res;
                SecondStarResult = dirSize;
            }
        }

        private void ProcessCommand(IReadOnlyList<string> input)
        {
            if (input[1] is "ls")
                return;
            if (input[1] is "cd")
                ProcessCd(input[2]);
        }

        private void ProcessCd(string cdTo)
        {
            switch (cdTo)
            {
                case "/":
                    _currentDirectory = _directories.Single(x => x.Name == "root");
                    break;
                case "..":
                    _currentDirectory = _currentDirectory.Parent ?? throw new InvalidOperationException();
                    break;
                default:
                    {
                        var dir = _directories.Where(x => x.Name == cdTo).SingleOrDefault(x => x.Parent is not null && x.Parent.IsSameDirectory(_currentDirectory));
                        if (dir is null)
                        {
                            dir = new Directory(_currentDirectory).SetName(cdTo);
                            _directories.Add(dir);
                        }
                        _currentDirectory = dir;
                    }
                    break;
            }
        }

        private void ProcessDir(string name)
        {
            var dir = _directories.Where(x => x.Name == name).SingleOrDefault(x => x.Parent is not null && x.Parent.IsSameDirectory(_currentDirectory));
            if (dir is not null)
                return;

            dir = new Directory(_currentDirectory).SetName(name);
            _currentDirectory.AddDirectory(dir);
            _directories.Add(dir);

        }

        protected void ProcessFile(int size, string name)
        {
            var file = _currentDirectory.Files.SingleOrDefault(x => x.Name == name);
            if (file is not null)
                return;

            file = new File(name).SetSize(size);
            _currentDirectory.AddFile(file);

        }
    }
}
