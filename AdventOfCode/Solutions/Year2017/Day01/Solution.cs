using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2017
{

    class Day01 : ASolution
    {
        private static int[] _digitsInSequence;
        public Day01() : base(01, 2017, "Inverse Captcha")
        {
            _digitsInSequence = Input.ToIntArray();
        }
        
        protected override string SolvePartOne()
        {
            var sum = 0;
            for (var lookupIndex = 0; lookupIndex < _digitsInSequence.Length; lookupIndex++)
            {
                var adjacentIndex = (lookupIndex + 1) % _digitsInSequence.Length;
                if (_digitsInSequence[lookupIndex] == _digitsInSequence[adjacentIndex]) sum += _digitsInSequence[lookupIndex];
            }

            return sum.ToString();
        }

        protected override string SolvePartTwo()
        {
            var sum = 0;
            for (var lookupIndex = 0; lookupIndex < _digitsInSequence.Length; lookupIndex++)
            {
                var targetIndex = (lookupIndex + (_digitsInSequence.Length / 2)) % _digitsInSequence.Length;
                if (_digitsInSequence[lookupIndex] == _digitsInSequence[targetIndex]) sum += _digitsInSequence[lookupIndex];
            }

            return sum.ToString();
        }
    }
}
