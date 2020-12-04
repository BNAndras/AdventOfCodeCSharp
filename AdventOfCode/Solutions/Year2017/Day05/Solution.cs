using System.Linq;

namespace AdventOfCode.Solutions.Year2017
{

    class Day05 : ASolution
    {
        private string[] InputJumps;
        public Day05() : base(05, 2017, "A Maze of Twisty Trampolines, All Alike")
        {
            InputJumps = Input.SplitByNewline(true).ToArray();
        }

        protected override string SolvePartOne()
        {
            var currentPosition = 0;
            var stepsTaken = 0;
            var availableJumps = InputJumps.Select(int.Parse).ToArray();
            while (currentPosition >= 0 && currentPosition < availableJumps.Length)
            {
                var nextJump = availableJumps[currentPosition];
                availableJumps[currentPosition]++;
                currentPosition += nextJump;
                stepsTaken++;

            }
            return stepsTaken.ToString();
        }

        protected override string SolvePartTwo()
        {
            var currentPosition = 0;
            var stepsTaken = 0;
            var availableJumps = InputJumps.Select(int.Parse).ToArray();
            while (currentPosition >= 0 && currentPosition < availableJumps.Length)
            {
                var nextJump = availableJumps[currentPosition];
                if (nextJump < 3) availableJumps[currentPosition]++;			
                else availableJumps[currentPosition]--;
                currentPosition += nextJump;
                stepsTaken++;
            }

            return stepsTaken.ToString();
        }
    }
}
