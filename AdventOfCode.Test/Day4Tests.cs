using AdventOfCode.Days;
using NUnit.Framework;

namespace AdventOfCode.Test
{
    public class Day4Tests
    {
        private readonly Day4 _day;
        public Day4Tests()
        {
            _day = new Day4();

        }

        [Test]
        public void OverLaps_Should_Return_True()
        {
            Assert.IsTrue(_day.OverLaps(1, 5, 2, 3));
        }

        [Test]
        public void OverLaps_Should_Return_False()
        {
            Assert.IsTrue(_day.OverLaps(1, 5, 2, 6));
        }
    }
}