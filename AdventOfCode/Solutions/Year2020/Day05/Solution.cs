using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions.Year2020
{

    class Day05 : ASolution
    {
        private static List<int> _seatIdSequences;

        private static readonly Dictionary<string, string> _charsToReplace = new Dictionary<string, string>()
        {
            {"F", "0"}, {"B", "1"}, {"L", "0"}, {"R", "1"}
        };
        public Day05() : base(05, 2020, "Binary Boarding")
        {
            var lines = Input.SplitByNewline();
            var seatIdSequencesNumbered = new List<int>();
            foreach (var line in lines)
            {
                // FBFBBFFRLR = 0101100101 = 357
                var seatIdSequence = MultipleReplace(line, _charsToReplace);
                seatIdSequencesNumbered.Add(Convert.ToInt32(seatIdSequence, fromBase: 2));
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
        
        private static string MultipleReplace(string text, Dictionary<string, string> replacements) {
            // https://metadeveloper.blogspot.com/2008/06/regex-replace-multiple-strings-in.html
            return Regex.Replace(text, 
                "(" + string.Join("|", replacements.Keys.ToArray()) + ")",
                m => replacements[m.Value]
            );
        }
    }
}
