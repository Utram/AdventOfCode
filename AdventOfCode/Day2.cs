using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    // https://adventofcode.com/2022/day/2
    internal class Day2
    {
        // A => Rock    X => Rock
        // B => Paper   Y => Paper
        // C => Scissor Z => Scissor

        // Rock     =   1
        // Paper    =   2
        // Scissor  =   3

        // Win      =   6
        // Draw     =   3
        // Lose     =   0

        // A x X = Draw (3) + 1 = 4
        // A x Y = Win  (6) + 2 = 8
        // A x Z = Lose (0) + 3 = 3
        // B x X = Lose (0) + 1 = 1
        // B x Y = Draw (3) + 2 = 5
        // B x Z = Win  (6) + 3 = 9
        // C x X = Win  (6) + 1 = 7
        // C x Y = Lose (0) + 2 = 2
        // C x Z = Draw (3) + 3 = 6
        private static Dictionary<string, int> _values = new Dictionary<string, int>
        {
            { "A X", 4 },
            { "A Y", 8 },
            { "A Z", 3 },
            { "B X", 1 },
            { "B Y", 5 },
            { "B Z", 9 },
            { "C X", 7 },
            { "C Y", 2 },
            { "C Z", 6 }
        };

        private static Dictionary<string, string> _win = new Dictionary<string, string>
        {
            { "A", "Y" },
            { "B", "Z" },
            { "C", "X" }
        };

        private static Dictionary<string, string> _draw = new Dictionary<string, string>
        {
            { "A", "X" },
            { "B", "Y" },
            { "C", "Z" }
        };

        private static Dictionary<string, string> _lose = new Dictionary<string, string>
        {
            { "A", "Z" },
            { "B", "X" },
            { "C", "Y" }
        };

        private static Dictionary<string, int> _shapeValues = new Dictionary<string, int>
        {
            { "X", 1 },
            { "Y", 2 },
            { "Z", 3 }
        };

        private static Dictionary<string, int> _conditionValues = new Dictionary<string, int>
        {
            { "WIN", 6 },
            { "DRAW", 3 },
            { "LOSE", 0 }
        };

        public static void Run()
        {
            Console.WriteLine("============== Running Code for Day2 ==============");
            Console.WriteLine();

            // Input Data: https://adventofcode.com/2022/day/2/input

            var input = File.ReadAllLines("./Input/Day2.txt");
            var score = 0;

            foreach (var line in input)
            {
                score += _values[line];
            }

            Console.WriteLine($"Final Score: {score}");
            Console.WriteLine();

            foreach (var line in input)
            {

            }

            Console.WriteLine();
            Console.WriteLine("============== End of Code for Day2 ==============");
            Console.WriteLine();
        }
    }
}
