namespace AdventOfCode.Days.Day7
{
    internal class Directory
    {
        public string Name { get; private set; }
        public List<File> Files { get; init; }
        public List<Directory> Directories { get; init; }

        public Directory? Parent { get; init; }

        public Directory(Directory? parent)
        {
            Files = new List<File>();
            Directories = new List<Directory>();
            Name = string.Empty;
            Parent = parent;
        }

        public Directory AddFile(File file)
        {
            Files.Add(file);
            return this;
        }

        public Directory SetName(string name)
        {
            Name = name;
            return this;
        }

        public Directory AddDirectory(Directory directory)
        {
            Directories.Add(directory);
            return this;
        }

        public int GetDirectorySize()
        {
            return Files.Sum(x => x.Size) + Directories.Sum(x => x.GetDirectorySize());
        }

        public bool IsSameDirectory(Directory other)
        {
            return DirectoryComparer.Equals(this, other);
        }

        private sealed class DirectoryEqualityComparer : IEqualityComparer<Directory>
        {
            public bool Equals(Directory x, Directory y)
            {
                if (ReferenceEquals(x, y)) return true;

                if (x.GetType() != y.GetType()) return false;
                return x.Name == y.Name && x.Files.Equals(y.Files) && x.Directories.Equals(y.Directories) && Equals(x.Parent, y.Parent);
            }

            public int GetHashCode(Directory obj)
            {
                return HashCode.Combine(obj.Name, obj.Files, obj.Directories, obj.Parent);
            }
        }

        public static IEqualityComparer<Directory> DirectoryComparer { get; } = new DirectoryEqualityComparer();
    }
}
