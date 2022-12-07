namespace AdventOfCode.Days.Day7
{
    internal class File
    {
        public string Name { get; init; }
        public int Size { get; private set; }

        public File(string name)
        {
            Name = name;
            Size = 0;
        }

        public File SetSize(int size)
        {
            Size = size;
            return this;
        }
    }
}
