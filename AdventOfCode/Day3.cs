namespace AdventOfCode
{
    // https://adventofcode.com/2022/day/3
    internal class Day3 : Day
    {
        public Day3() : base(3)
        {
        }

        protected override void RunLogic(string[] input)
        {
            // Part 1
            var score = 0;

            foreach (var line in input)
            {
                var compartmentOne = line.Substring(0, line.Length / 2);
                var compartmentTwo = line.Substring(line.Length / 2);

                for (int i = 0; i < compartmentOne.Length; i++)
                {
                    if (compartmentTwo.Contains(compartmentOne[i]))
                    {
                        AddToScore(compartmentOne[i], ref score);
                        break;
                    }
                }
            }

            Console.WriteLine($"Final Score: {score}");

            // Part 2
            score = 0;
            var groupSize = 3;

            for (int i = 0; i < input.Length / groupSize; i++)
            {
                var group = input.Skip(i * groupSize)
                                 .Take(groupSize)
                                 .ToArray();

                // Check and compare items of first member
                foreach (var item in group[0])
                {
                    if (group[1].Contains(item) && group[2].Contains(item))
                    {
                        AddToScore(item, ref score);
                        break;
                    }
                }
            }

            Console.WriteLine($"Group Score: {score}");
        }

        private void AddToScore(char c, ref int currentValue)
        {
            // https://www.cs.cmu.edu/~pattis/15-1XX/common/handouts/ascii.html
            // Berechnung des char-Werts über den ASCII Wert
            // Upper Case entspricht ASCII < 97
            // Lower Case entspricht ASCII > 97
            // a => 97 % 32         = 1
            // A => 64 % 32 + 26    = 26
            if (c < 97)
            {
                currentValue += (c % 32 + 26);
            }
            else
            {
                currentValue += (c % 32);
            }
        }
    }
}