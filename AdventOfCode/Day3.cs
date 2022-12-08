namespace AdventOfCode
{
    // https://adventofcode.com/2022/day/3
    internal class Day3
    {
        private static Dictionary<char, int> _priorities = new Dictionary<char, int>
        {
            { 'a', 1 },
            { 'b', 2 },
            { 'c', 3 },
            { 'd', 4 },
            { 'e', 5 },
            { 'f', 6 },
            { 'g', 7 },
            { 'h', 8 },
            { 'i', 9 },
            { 'j', 10 },
            { 'k', 11 },
            { 'l', 12 },
            { 'm', 13 },
            { 'n', 14 },
            { 'o', 15 },
            { 'p', 16 },
            { 'q', 17 },
            { 'r', 18 },
            { 's', 19 },
            { 't', 20 },
            { 'u', 21 },
            { 'v', 22 },
            { 'w', 23 },
            { 'x', 24 },
            { 'y', 25 },
            { 'z', 26 },
            { 'A', 27 },
            { 'B', 28 },
            { 'C', 29 },
            { 'D', 30 },
            { 'E', 31 },
            { 'F', 32 },
            { 'G', 33 },
            { 'H', 34 },
            { 'I', 35 },
            { 'J', 36 },
            { 'K', 37 },
            { 'L', 38 },
            { 'M', 39 },
            { 'N', 40 },
            { 'O', 41 },
            { 'P', 42 },
            { 'Q', 43 },
            { 'R', 44 },
            { 'S', 45 },
            { 'T', 46 },
            { 'U', 47 },
            { 'V', 48 },
            { 'W', 49 },
            { 'X', 50 },
            { 'Y', 51 },
            { 'Z', 52 }
        };

        public static void Run()
        {
            Console.WriteLine("============== Running Code for Day3 ==============");
            Console.WriteLine();

            // Input Data: https://adventofcode.com/2022/day/3/input

            var input = File.ReadAllLines("./Input/Day3.txt");
            
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
                        score += _priorities[compartmentOne[i]];
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
                        score += _priorities[item];
                        break;
                    }
                }
            }

            Console.WriteLine($"Group Score: {score}");

            Console.WriteLine();
            Console.WriteLine("============== End of Code for Day3 ===============");
            Console.WriteLine();
        }
    }
}

