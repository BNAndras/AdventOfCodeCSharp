using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AdventOfCode.Solutions.Year2017
{

    class Day03 : ASolution
    {

        public Day03() : base(03, 2017, "Spiral Memory")
        {
            FinalPosition = int.Parse(Input);
        }

        private static int FinalPosition { get; set; }
        protected override string SolvePartOne()
        {
            if (FinalPosition == 1) return "0";
            var ringRadius = int.Parse(Math.Sqrt(FinalPosition).ToString());
            while (true)
            {
                if (ringRadius % 2 == 1 && Math.Pow(ringRadius, 2) % 2 == 1) break;
                else ringRadius++;
            }

            var bottomRight = int.Parse(Math.Sqrt(FinalPosition).ToString());
            if (FinalPosition == bottomRight) return (ringRadius - 1).ToString();
            else
            {
                var distanceToHigherCorner = (bottomRight - FinalPosition) % ringRadius;
                var distanceToLowerCorner = Math.Abs((FinalPosition + distanceToHigherCorner) - ringRadius);
                var distanceToOrigin = ringRadius - Math.Min(distanceToHigherCorner, distanceToLowerCorner) -1;
                return distanceToOrigin.ToString();
            }
        }

        protected override string SolvePartTwo()
        {
            return null;
        }
    }
}