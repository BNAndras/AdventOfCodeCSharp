using System;
using System.Collections.Generic;

namespace AdventOfCode.Solutions.Year2020
{

    class Day01 : ASolution
    {

        private static readonly int _goal = 2020;
        private static List<int> Costs {set; get;}
        
        public Day01() : base(01, 2020, "Report Repair")
        {

            var costs = new List<int>();
            var inputs = Input.SplitByNewline(true);
            foreach (var input in inputs)
            {
                costs.Add(Convert.ToInt32(input));
            }

            costs.Sort();
            Costs = costs;
        }

        protected override string SolvePartOne()
        {
            for (var i = 0; i < Costs.Count - 2; i++)
            {
                for (var j = 0; j < Costs.Count - 1; j++)
                {
                    var sum = Costs[i] + Costs[j];
                    if (sum > _goal) break;
                    if (sum == _goal) return (Costs[i] * Costs[j]).ToString();
                }
            }

            return "";
        }

        protected override string SolvePartTwo()
        {
            for (var i = 0; i < Costs.Count - 2; i++)
            {
                for (var j = 0; j < Costs.Count - 1; j++)
                {
                    var sum = Costs[i] + Costs[j];
                    if (sum > _goal) break;
                    for (int k = 0; k < Costs.Count; k++)
                    {
                        sum = Costs[i] + Costs[j] + Costs[k];
                        if (sum > _goal) break;
                        if (sum == _goal) return (Costs[i] * Costs[j] * Costs[k]).ToString();

                    }
                }
            }

            return "";
        }
    }
}