namespace AdventOfCode.Solutions.Year2020
{

    class Day02 : ASolution
    {
        private static string[] Lines;
        public Day02() : base(02, 2020, "Password Philosophy")
        {
            Lines = Input.SplitByNewline(true);
        }

        protected override string SolvePartOne()
        {
            var counterPassword = 0;
            foreach (var line in Lines)
            {
                var segments = line.Split(new[] {'-', ' ', ':'});
                var minOccurence = int.Parse(segments[0]);
                var maxOccurence = int.Parse(segments[1]);
                var charToCheck = segments[2][0];
                var password = segments[^1];
                var counterChar = 0;
                foreach (var c in password)
                {
                    if (c == charToCheck) counterChar++;
                }

                if ((minOccurence <= counterChar) && (maxOccurence >= counterChar)) counterPassword++;
            }
            return counterPassword.ToString();
        }

        protected override string SolvePartTwo()
        {
            var counterPassword = 0;
            foreach (var line in Lines)
            {
                var segments = line.Split(new[] {'-', ' ', ':'});
                var firstPosition = int.Parse(segments[0]) - 1;
                var secondPosition = int.Parse(segments[1]) - 1;
                var charToCheck = segments[2][0];
                var password = segments[^1];
                if (
                    ((password[firstPosition] == charToCheck) | (password[secondPosition] == charToCheck))
                    && (password[firstPosition] != password[secondPosition])
                    )
                    counterPassword += 1;
            }
            return counterPassword.ToString();
        }
    }
}