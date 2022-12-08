using AdventOfCode.Days;
using AdventOfCode.Days.Day7;
using AdventOfCode.Days.Day8;

namespace AdventOfCode
{
    internal static class DayHelper
    {
        internal static BaseDay GetDayClass(int day)
        {
            switch (day)
            {
                case 1:
                    return new Day1();
                case 2:
                    return new Day2();
                case 3:
                    return new Day3();
                case 4:
                    return new Day4();
                case 5:
                    return new Day5();
                case 6:
                    return new Day6();
                case 7:
                    return new Day7();
                case 8:
                    return new Day8();
                case 9:
                    return new Day1();
                case 10:
                    return new Day1();
                case 11:
                    return new Day1();
                case 12:
                    return new Day1();
                case 13:
                    return new Day1();
                case 14:
                    return new Day1();
            }

            return new Day1();
        }
    }
}
