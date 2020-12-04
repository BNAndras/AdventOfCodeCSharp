using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day04 : ASolution
    {
        private static List<List<string>> PassportLinesOfLines;

        private static readonly HashSet<string> RequiredFields =
        new HashSet<string>() {
            "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"
        };

        private static readonly string[] OptionalFields =
        {
            "cid"
        };
        
        public Day04() : base(04, 2020, "Passport Processing")
        {
        }

        protected override string SolvePartOne()
        {
            var lines = Input.Split(Environment.NewLine).ToList();
            lines.Add(string.Empty);
            var counterValidPassports = 0;
            var passportFields = new List<string>();
            foreach (var line in lines)
            {
                var distinctPassportFields = new HashSet<string>(passportFields);
                if (line == string.Empty && distinctPassportFields.SetEquals(RequiredFields)) counterValidPassports++;
                if (line == string.Empty)
                {
                    passportFields = new List<string>();
                    continue;
                }

                foreach (var segment in line.Split(" "))
                {
                    var fieldName = segment.Split(':')[0];
                    if (RequiredFields.Contains(fieldName)) passportFields.Add(segment.Split(':')[0]);
                }
            }

            return counterValidPassports.ToString();
        }

        protected override string SolvePartTwo()
        {
            return null;
        }
    }
}

