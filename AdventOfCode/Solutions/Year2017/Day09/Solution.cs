using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2017
{

    class Day09 : ASolution
    {

        public Day09() : base(09, 2017, "")
        {

        }

        protected override string SolvePartOne()
        {
            var totalScore = 0;
            var runningNestedTally = 0;
            var skipNextC = false;
            var garbageActive = false;
            foreach (var c in Input)
            {
                if (skipNextC)
                {
                    skipNextC = !skipNextC;
                    continue;
                }
                switch (c)
                {
                    case '!':
                        skipNextC = true;
                        break;
                    case '<':
                        if (!garbageActive) garbageActive = !garbageActive;
                        break;
                    case '>':
                        garbageActive = false;
                        break;
                    case '{':
                        if (!garbageActive) runningNestedTally++;
                        break;
                    case '}':
                        if (!garbageActive)
                        {
                            totalScore += runningNestedTally;
                            runningNestedTally--;
                        }
                        break;
                }
            }

            return totalScore.ToString();
        }

        protected override string SolvePartTwo()
        {
            var removedCharacters = 0;
            var runningNestedTally = 0;
            var skipNextC = false;
            var garbageActive = false;
            foreach (var c in Input)
            {
                if (skipNextC)
                {
                    skipNextC = !skipNextC;
                    continue;
                }
                switch (c)
                {
                    case '!':
                        skipNextC = true;
                        break;
                    case '<':
                        if (!garbageActive) garbageActive = !garbageActive;
                        else removedCharacters++;
                        break;
                    case '>':
                        garbageActive = false;
                        break;
                    case '{':
                        if (!garbageActive) runningNestedTally++;
                        else removedCharacters++;
                        break;
                    case '}':
                        if (!garbageActive) runningNestedTally--;
                        else removedCharacters++;
                        break;
                    default:
                        if (garbageActive) removedCharacters++;
                        break;
                }

            }
            return removedCharacters.ToString();
        }
    }
}
