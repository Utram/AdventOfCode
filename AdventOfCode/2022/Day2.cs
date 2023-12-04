namespace AdventOfCode.Y2022
{
    // https://adventofcode.com/2022/day/2
    internal class Day2 : Day
    {
        public Day2() : base(2022, 2)
        {
        }

        // Part 1

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

        // Part 2

        // X => You Lose
        // Y => Draw
        // Z => You Win

        // A x X = Z
        // A x Y = X
        // A x Z = Y
        // B x X = X
        // B x Y = Y
        // B x Z = Z
        // C x X = Y
        // C x Y = Z
        // C x Z = X
        private static Dictionary<string, string> _transformations = new Dictionary<string, string>
        {
            { "A X", "Z" },
            { "A Y", "X" },
            { "A Z", "Y" },
            { "B X", "X" },
            { "B Y", "Y" },
            { "B Z", "Z" },
            { "C X", "Y" },
            { "C Y", "Z" },
            { "C Z", "X" }
        };

        protected override void RunLogic(string[] input)
        {
            var score = 0;

            foreach (var line in input)
            {
                score += _values[line];
            }

            Console.WriteLine($"Final Score: {score}");
            Console.WriteLine();

            score = 0;

            foreach (var line in input)
            {
                var decisions = line.Split(' ');
                var strategyDecision = line.Replace(decisions[1], _transformations[line]);
                score += _values[strategyDecision];
            }

            Console.WriteLine($"Final Score with adjusted strategy: {score}");
            Console.WriteLine();
        }
    }
}