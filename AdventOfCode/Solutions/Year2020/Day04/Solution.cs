using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions.Year2020
{

    class Day04 : ASolution
    {
        private static List<string> PassportLines;

        private static readonly HashSet<string> RequiredFields =
        new HashSet<string>() {
            "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"
        };

        private static readonly string[] OptionalFields =
        {
            "cid"
        };

        private static readonly string[] ValidEyeColorCodes =
        {
            "amb","blu", "brn", "gry", "grn", "hzl", "oth", 
        };
        
        public Day04() : base(04, 2020, "Passport Processing")
        {
            var lines = Input.Split(Environment.NewLine).ToList();
            lines.Add(string.Empty);
            PassportLines = lines;
        }

        protected override string SolvePartOne()
        {

            var counterValidPassports = 0;
            var passportFields = new List<string>();
            foreach (var line in PassportLines)
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
            var counterValidPassports = 0;
            var passportFields = new List<string>();
            foreach (var line in PassportLines)
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
                    var valueToValidate = segment.Split(':')[1];
                    var validationToggle = false;
                    var _ = int.TryParse(valueToValidate, out var yearToValidate);
                    switch (fieldName)
                    {
                        case "byr":
                            if ((1920 <= yearToValidate) && (yearToValidate <= 2002)) validationToggle = true;
                            break;
                        case "iyr":
                            if ((2010 <= yearToValidate) && (yearToValidate <= 2020)) validationToggle = true;
                            break;
                        case "eyr":
                            if ((2020 <= yearToValidate) && (yearToValidate <= 2030)) validationToggle = true;
                            break;
                        case "hgt":
                            var unit = valueToValidate[^2..];
                            var __ = int.TryParse(valueToValidate[..^2], out var height);
                            switch (unit)
                            {
                                case "cm" when ((150 <= height) && (height <= 193)):
                                    validationToggle = true;
                                    break;
                                case "in" when ((59 <= height) && (height <= 76)):
                                    validationToggle = true;
                                    break;
                            }
                            break;
                        case "hcl":
                            var hclRegex = new Regex(@"^#[0-9a-f]{6}$");
                            if (hclRegex.IsMatch(valueToValidate)) validationToggle = true;
                            break;
                        case "ecl":
                            if (ValidEyeColorCodes.Contains(valueToValidate)) validationToggle = true;
                            break;
                        case "pid":
                            var pidRegex = new Regex(@"^\d{9}$");
                            if (pidRegex.IsMatch(valueToValidate)) validationToggle = true;
                            break;
                    }
                    if (validationToggle) passportFields.Add(fieldName);
                }
            }
            
            return counterValidPassports.ToString();
        }
    }
}