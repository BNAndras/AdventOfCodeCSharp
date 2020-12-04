using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2017
{

    class Day06 : ASolution
    {
        public Day06() : base(06, 2017, "")
        {

        }

        protected override string SolvePartOne()
        {
            var seenConfigurations = new List<List<int>>();
            var activeMemoryBanks = Input.Split("\t").Select(Int32.Parse).ToList();
    
            while (!seenConfigurations.Any
        (
        seenConfiguration => Enumerable.SequenceEqual(seenConfiguration, activeMemoryBanks)
        )
        )
            {seenConfigurations.Add(activeMemoryBanks.ConvertAll(memoryBank => memoryBank));
                activeMemoryBanks = distributeBankValues(activeMemoryBanks);}
            return seenConfigurations.Count().ToString();
        }

        protected override string SolvePartTwo()
        {
            var seenConfigurations = new List<List<int>>();
            var activeMemoryBanks = Input.Split("\t").Select(Int32.Parse).ToList();
                while (!seenConfigurations.Any
            (
            seenConfiguration => Enumerable.SequenceEqual(seenConfiguration, activeMemoryBanks)
            )
            )
            {seenConfigurations.Add(activeMemoryBanks.ConvertAll(memoryBank => memoryBank));
                activeMemoryBanks = distributeBankValues(activeMemoryBanks);
            }
        
            var firstSeenInstance = seenConfigurations.IndexOf
                (
                    seenConfigurations.First
                    (
                        seenConfiguration => Enumerable.SequenceEqual(seenConfiguration, activeMemoryBanks)
                    )
                );
        return (seenConfigurations.Count() - firstSeenInstance).ToString();
        }

        private static List<int> distributeBankValues(List<int> currentMemoryBanks)
        {
    
            int currentIndex = currentMemoryBanks.IndexOf(currentMemoryBanks.Max());
            int availableBlocks = currentMemoryBanks[currentIndex];
            currentMemoryBanks[currentIndex] = 0;  // should be populated with any leftover
            currentIndex++;
        
            while (availableBlocks > 0)
            {
                currentIndex = currentIndex % currentMemoryBanks.Count();
                currentMemoryBanks[currentIndex]++;
                availableBlocks--;
                currentIndex++;
            }
        return currentMemoryBanks;
        }
    }
}
