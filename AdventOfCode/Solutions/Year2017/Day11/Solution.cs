using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode.Solutions.Year2017
{

    class Day11 : ASolution
    {

        public Day11() : base(11, 2017, "")
        {
            var shifts = new List<(int, int)>();
            foreach (var direction in Input.Split(",", StringSplitOptions.RemoveEmptyEntries))
            {
                shifts.Add(MoveTowards(direction));
            }

            Shifts = shifts;
        }

        private List<(int, int)> Shifts { get; set; }

        protected override string SolvePartOne()
        {
            var destination =
                Shifts.Aggregate(((shift1, shift2) => (shift1.Item1 + shift2.Item1, shift1.Item2 + shift2.Item2)));
            // dy + (dx - dy / 2) https://stackoverflow.com/a/14492121
            var distance = Math.Abs(destination.Item2) +
                           ((Math.Abs(destination.Item1) - Math.Abs(destination.Item2)) / 2);
            return distance.ToString();
        }

        protected override string SolvePartTwo()
        {
            var maxDistance = 0;
            var currentPosition = (0, 0);
            foreach (var shift in Shifts)
            {
                currentPosition = ((currentPosition.Item1 + shift.Item1), (currentPosition.Item2 + shift.Item2));
                var distance = Math.Abs(currentPosition.Item2) +
                               ((Math.Abs(currentPosition.Item1) - Math.Abs(currentPosition.Item2)) / 2);
                if (distance > maxDistance) maxDistance = distance;
            }

            return maxDistance.ToString();
        }

        private static (int, int) MoveTowards(string direction)
        {
            switch (direction)
            {
                case "n":
                    return (0, 2);

                case "ne":
                    return (1, 1);

                case "se":
                    return (1, -1);

                case "s":
                    return (0, -2);

                case "sw":
                    return (-1, -1);

                case "nw":
                    return (-1, 1);

                default:
                    throw new ArgumentException($"No case implemented for case '{direction}'");
            }
        }
    }
}
