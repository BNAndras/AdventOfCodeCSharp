using System;
using System.Collections.Generic;

namespace AdventOfCode.Solutions.Year2020
{

    class Day05 : ASolution
    {
        private static string[] SeatIDSequences;
        public Day05() : base(05, 2020, "")
        {
            // FBFBBFFRLR equals 357, but 357 in base 2 is ..
            // 0101100101
            var lines = Input.SplitByNewline();
            for (var i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].Replace('F', '0').Replace('B', '1').Replace('R', '1').Replace('L', '0');
            }

            SeatIDSequences = lines;
        }

        protected override string SolvePartOne()
        {
            var highestSeatId = 0;
            foreach (var seatIdSequence in SeatIDSequences)
            {
                var currentSeatId = Convert.ToInt32(seatIdSequence, fromBase: 2);
                if (currentSeatId > highestSeatId) highestSeatId = currentSeatId;
            }
            return highestSeatId.ToString();
        }

        protected override string SolvePartTwo()
        {
            var takenSeats = new List<int>();
            foreach (var seatIdSequence in SeatIDSequences)
            {
                takenSeats.Add(Convert.ToInt32(seatIdSequence, fromBase: 2));
            }
            // BBBBBBBRRR last seat
            // 1111111000 = 1016
            for (var currentSeatId = 0; currentSeatId < 1016; currentSeatId++)
            {
                if (takenSeats.Contains(currentSeatId - 1) && takenSeats.Contains(currentSeatId + 1) && !takenSeats.Contains(currentSeatId))
                {
                    return currentSeatId.ToString();
                }
            }

            return "";
        }
    }
}
