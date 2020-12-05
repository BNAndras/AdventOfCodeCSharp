using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2020
{

    class Day05 : ASolution
    {
        private static List<int> _seatIdSequences;
        public Day05() : base(05, 2020, "Binary Boarding")
        {
            var lines = Input.SplitByNewline();
            var seatIdSequencesNumbered = new List<int>();
            for (var i = 0; i < lines.Length; i++)
            {
                // FBFBBFFRLR
                // 0101100101
                // 357
                lines[i] = lines[i].Replace('F', '0')
                    .Replace('B', '1')
                    .Replace('R', '1')
                    .Replace('L', '0');
                seatIdSequencesNumbered.Add(Convert.ToInt32(lines[i], fromBase: 2));
            }

            _seatIdSequences = seatIdSequencesNumbered;
        }

        protected override string SolvePartOne()
        {
            return _seatIdSequences.Max().ToString();
        }

        protected override string SolvePartTwo()
        {
            // BBBBBBBRRR (first)        BBBBBBBRRR (last)
            // 0000000111                1111111000 
            // 7                         1016
            for (var currentSeatId = 8; currentSeatId < 1016; currentSeatId++)
            {
                if (
                    !_seatIdSequences.Contains(currentSeatId)
                    && _seatIdSequences.Contains(currentSeatId - 1)
                    && _seatIdSequences.Contains(currentSeatId + 1)
                ) return currentSeatId.ToString();
            }

            return "";
        }
    }
}
