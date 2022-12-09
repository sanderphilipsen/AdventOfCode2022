namespace AdventOfCode
{
    public static class Helpers
    {
        public static string[] ReadInput(int day, bool b = false)
        => File.ReadAllLines($@"C:\Users\sphilipsen\Projects\Private\AdventOfCode2022\AdventOfCode\Inputs\day{day}{(b ? "b" : "")}.txt");

        public static int FindIndex<T>(this string[] array, T item)
        => Array.FindIndex(array, val => val.Equals(item));


    }
}
