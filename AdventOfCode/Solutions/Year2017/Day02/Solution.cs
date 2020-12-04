using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2017
{

    class Day02 : ASolution
    {
        private static string[] _lines;
        public Day02() : base(02, 2017, "Corruption Checksum")
        { 
            _lines = Input.SplitByNewline();
        }
        
        protected override string SolvePartOne()
        {
            var rowChecksums = new List<int>();

            foreach (var line in _lines)
            {
                var rowOfNumbers = line.Trim().Split('\t');
                var numbers = new List<int>();
                foreach (var rowNumber in rowOfNumbers)
                {
                    numbers.Add(int.Parse(rowNumber));
                }
                rowChecksums.Add(numbers.Max() - numbers.Min());
            }

            return rowChecksums.Sum().ToString();
        }

        protected override string SolvePartTwo()
        {
            var rowChecksums = new List<int>();

            foreach (var line in _lines)
            {
                var rowOfNumbers = line.Trim().Split('\t');
                var numbers = new List<int>();
                foreach (var rowNumber in rowOfNumbers)
                {
                    numbers.Add(int.Parse(rowNumber));
                }
                foreach (var outerNum in numbers)
                {
                    foreach (var innerNum in numbers)
                    {
                        if (outerNum % innerNum == 0 & outerNum != innerNum) rowChecksums.Add(outerNum / innerNum);
                    }
                }
            }

            return rowChecksums.Sum().ToString();
        }
    }
}
