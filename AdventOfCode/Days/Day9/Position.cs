using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days.Day9
{
    internal class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y) { 
            X= x;
            Y= y;
        }

        public Position InitializeInCenter()
        {
            X = 0;
            Y = 0;
            return this;
        }
        public void MoveRight()
        {
            X++;
            
        }
        public void MoveLeft()
        {
            X--;

        }
        public void MoveUp()
        {
           Y++;
        }
        public void MoveDown()
        {
           Y--;
        }
    }
}
