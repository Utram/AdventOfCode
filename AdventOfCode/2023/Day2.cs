using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AdventOfCode.Y2023
{
    // https://adventofcode.com/2023/day/2
    internal class Day2 : Day
    {
        public Day2() : base(2023, 2)
        {
        }

        protected override void RunLogic(string[] input)
        {
            // Part 1

            var sumOfGameIds = 0;

            var redUpperLimit = 12;
            var greenUpperLimit = 13;
            var blueUpperLimit = 14;

            Console.WriteLine(); 
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Part 1");
            Console.WriteLine();

            for (var i = 0; i < input.Length; i++)
            {
                var sets       = input[i].Split(":", StringSplitOptions.TrimEntries)[1].Split(";", StringSplitOptions.TrimEntries);
                
                var redRolls   = sets.SelectMany(x => x.Split(",")
                                                        .Where(x => x.Contains("red"))
                                                        .Select(x => int.Parse(x.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0])));

                var greenRolls = sets.SelectMany(x => x.Split(",")
                                                        .Where(x => x.Contains("green"))
                                                        .Select(x => int.Parse(x.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0])));

                var blueRolls  = sets.SelectMany(x => x.Split(",")
                                                        .Where(x => x.Contains("blue"))
                                                        .Select(x => int.Parse(x.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0])));

                var isAnyLimitViolated = redRolls.Any(x => x > redUpperLimit) ||
                                         greenRolls.Any(x => x > greenUpperLimit) ||
                                         blueRolls.Any(x => x > blueUpperLimit);

                if (!isAnyLimitViolated)
                {
                    sumOfGameIds += i + 1;
                }
            }
            
            Console.WriteLine();
            Console.WriteLine($"Sum of valid GameIds: {sumOfGameIds}");
            Console.WriteLine();

            // Part 2

            var sumOfMinSetPower = 0d;

            for (var i = 0; i < input.Length; i++)
            {
                var sets     = input[i].Split(":", StringSplitOptions.TrimEntries)[1].Split(";", StringSplitOptions.TrimEntries);
                
                var redRolls   = sets.SelectMany(x => x.Split(",")
                                                        .Where(x => x.Contains("red"))
                                                        .Select(x => int.Parse(x.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0])));

                var greenRolls = sets.SelectMany(x => x.Split(",")
                                                        .Where(x => x.Contains("green"))
                                                        .Select(x => int.Parse(x.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0])));

                var blueRolls  = sets.SelectMany(x => x.Split(",")
                                                        .Where(x => x.Contains("blue"))
                                                        .Select(x => int.Parse(x.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0])));

                var maxRedCubes   = redRolls.Max();
                var maxGreenCubes = greenRolls.Max();
                var maxBlueCubes  = blueRolls.Max();

                var powerOfMinCubes = maxRedCubes * maxGreenCubes * maxBlueCubes;

                sumOfMinSetPower += powerOfMinCubes;
            }

            Console.WriteLine();
            Console.WriteLine("Part 2");
            Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine($"Sum of power of minimum sets: {sumOfMinSetPower}");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();
        }
    }
}
