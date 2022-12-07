namespace AdventOfCode.Days.Day7
{
    internal class Day7 : BaseDay
    {

        private Directory _currentDirectory;
        private List<Directory> directories;
        private int capacity = 70000000;
        private int totalUsed = 0;
        private int updateRequiredSpace = 30000000;
        private int spaceToMakeFree = 0;


        public Day7() : base(7, false)
        {
            directories = new List<Directory>();
            _currentDirectory = new Directory(null).SetUniqueName("root", null).SetLevel(0);
            directories.Add(_currentDirectory);
        }

        protected override void ExecuteDay(string[] lines, string[]? linesForB = null)
        {
            foreach (var line in lines)
            {
                var input = line.Split(" ");
                if (input[0] == "$")
                    ProcessCommand(input);
                else if (int.TryParse(input[0], out var size))
                    ProcessFile(size, input[1]);
                else if (input[0] == "dir")
                    ProcessDir(input[1]);
            }

            CalculateFirsStarResult();
            CalculateSecondStarResult();

            PrintResults();
        }

        private void CalculateFirsStarResult()
        {
            foreach (var directory in directories)
            {
                var dirSize = directory.GetDirectorySize();
                if (dirSize <= 100000)
                    FirstStarResult += dirSize;
            }

            _currentDirectory = directories.Single(x => x.Name == "root");
            this.spaceToMakeFree = (_currentDirectory.GetDirectorySize() + updateRequiredSpace) - capacity;

        }

        private void CalculateSecondStarResult()
        {
            var bestSolution = capacity;
            foreach (var directory in directories)
            {
                var dirSize = directory.GetDirectorySize();
                var res = dirSize - spaceToMakeFree;
                if (res >= 0 && res < bestSolution)
                {
                    bestSolution = res;
                    SecondStarResult = dirSize;
                }
            }
        }
        protected void ProcessCommand(string[] input)
        {
            if (input[1] == "ls")
                return;
            if (input[1] == "cd")
                ProcessCd(input[2]);

        }
        protected void ProcessCd(string cdTo)
        {
            switch (cdTo)
            {
                case "/":
                    _currentDirectory = directories.Single(x => x.Name == "root");
                    break;
                case "..":
                    _currentDirectory = _currentDirectory.Parent ?? throw new InvalidOperationException();
                    break;
                default:
                    {
                        var dir = directories.Where(x => x.Name == cdTo).SingleOrDefault(x => x.Parent.IsSameDirectory(_currentDirectory));
                        if (dir is null)
                        {
                            dir = new Directory(_currentDirectory).SetUniqueName(cdTo, null);
                            directories.Add(dir);
                        }

                        _currentDirectory = dir;
                    }
                    break;
            }
        }

        protected void ProcessDir(string name)
        {
            var dir = directories.Where(x => x.Name == name).SingleOrDefault(x => x.Parent.IsSameDirectory(_currentDirectory));
            if (dir is null)
            {
                dir = new Directory(_currentDirectory).SetUniqueName(name, null);
                _currentDirectory.AddDirectory(dir);
                directories.Add(dir);
            }
        }

        protected void ProcessFile(int size, string name)
        {
            var file = _currentDirectory.Files.SingleOrDefault(x => x.Name == name);
            if (file is null)
            {
                file = new File(name).SetSize(size);
                _currentDirectory.AddFile(file);
            }
        }
    }
}
