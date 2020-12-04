namespace AdventOfCode.Solutions.Year2020
{
    class Day03 : ASolution
    {
        private static string[] _lines;
        private static int _heightOfGrid;
        private static int _widthOfGrid;
        private const char TreeSymbol = '#';
        private static readonly (int X, int Y) StartingPosition = (0, 0);
        private static readonly (int deltaY, int deltaX)[] PossibleSlopes = new[]
        {
            (1, 3), (1, 1), (1, 5), (1, 7), (2, 1)
        };
        
        public Day03() : base(03, 2020, "Toboggan Trajectory")
        {
            _lines = Input.SplitByNewline();
            _heightOfGrid = _lines.Length;
            _widthOfGrid = _lines[0].Length;
        }
        
        protected override string SolvePartOne()
        {
            return CountTreesIntersectedBySlopeOf(PossibleSlopes[0]).ToString();
        }

        protected override string SolvePartTwo()
        {
            var treesEncountered = CountTreesIntersectedBySlopeOf(PossibleSlopes[0]);
            foreach (var slope in PossibleSlopes[1..])
            { 
                treesEncountered *= CountTreesIntersectedBySlopeOf(slope);
            }

            return treesEncountered.ToString();
        }

        private static int CountTreesIntersectedBySlopeOf((int deltaY, int deltaX) slope)
        {
            var treesEncountered = 0;
            var currentPosition = StartingPosition;
            while (currentPosition.Y < _heightOfGrid)
            {
                if (_lines[currentPosition.Y][currentPosition.X % _widthOfGrid] == TreeSymbol) treesEncountered += 1;
                currentPosition = (X: currentPosition.X + slope.deltaX, Y: currentPosition.Y + slope.deltaY);
            }
            
            return treesEncountered;
        }
    }
}
