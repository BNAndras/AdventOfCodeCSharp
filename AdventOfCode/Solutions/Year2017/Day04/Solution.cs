using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode.Solutions.Year2017
{

    class Day04 : ASolution
    {
        private string[] Lines;
        public Day04() : base(04, 2017, "High-Entropy Passphrases")
        {
            Lines = Input.SplitByNewline();
        }
        
        protected override string SolvePartOne()
        {
            var validPassphrases = 0;
            foreach (var passphrase in Lines)
            {
                var words = passphrase.Split(" ").ToList();
                if (words.Count > 1 && words.Count == words.Distinct().Count()) validPassphrases++;
            }

            return validPassphrases.ToString();
        }
        
        protected override string SolvePartTwo()
        {
            var validPassphrases = 0;
            foreach (var passphrase in Lines)
            {
                var words = passphrase.Split(" ").ToList();
                var wordsSorted = new List<string>();
                foreach (var word in words)
                {
                    var chars = word.ToCharArray();
                    Array.Sort(chars);
                    wordsSorted.Add(new string(chars));
                }
                if (wordsSorted.Count >1 && wordsSorted.Count == wordsSorted.Distinct().Count()) validPassphrases++;
            }

            return validPassphrases.ToString();
        }
    }
}
