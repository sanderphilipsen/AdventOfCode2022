namespace AdventOfCode
{
    public static class Helpers
    {
        public static string[] ReadInput(int day, bool b = false)
        {
            string[] lines = File.ReadAllLines($@"C:\Users\sphilipsen\source\repos\AdventOfCode\AdventOfCode\Inputs\day{day}{(b ? "b" : "")}.txt");
            return lines;
        }
        public static int FindIndex<T>(this T[] array, T item)
        {
            return Array.FindIndex(array, val => val.Equals(item));
        }
    }
}
