using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AdventOfCode.Y2023
{
    // https://adventofcode.com/2023/day/1
    internal class Day2 : Day
    {
        public Day2() : base(2023, 2)
        {
        }

        protected override void RunLogic(string[] input)
        {
            // Part 1

            var gameIdSum = 0;

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
                var sets       = input[i].Split(":", StringSplitOptions.TrimEntries)[1].Split(";");
                var games      = sets.SelectMany(x => x.Split(";", StringSplitOptions.TrimEntries));
                var redRolls   = games.SelectMany(x => x.Split(",")
                                                        .Where(x => x.Contains("red"))
                                                        .Select(x => int.Parse(x.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0])));

                var greenRolls = games.SelectMany(x => x.Split(",")
                                                        .Where(x => x.Contains("green"))
                                                        .Select(x => int.Parse(x.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0])));

                var blueRolls  = games.SelectMany(x => x.Split(",")
                                                        .Where(x => x.Contains("blue"))
                                                        .Select(x => int.Parse(x.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0])));

                var isAnyLimitViolated = redRolls.Any(x => x > redUpperLimit) ||
                                         greenRolls.Any(x => x > greenUpperLimit) ||
                                         blueRolls.Any(x => x > blueUpperLimit);

                if (!isAnyLimitViolated)
                {
                    gameIdSum += i + 1;
                }
            }
            
            Console.WriteLine();
            Console.WriteLine($"Sum of valid GameIds: {gameIdSum}");
            Console.WriteLine();

            // Part 2

            Console.WriteLine();
            Console.WriteLine("Part 2");
            Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();
        }
    }
}
