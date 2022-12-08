namespace AdventOfCode
{
    // https://adventofcode.com/2022/day/4
    internal class Day4
    {
        public static void Run()
        {
            Console.WriteLine("============== Running Code for Day4 ==============");
            Console.WriteLine();

            // Input Data: https://adventofcode.com/2022/day/4/input

            var input = File.ReadAllLines("./Input/Day4.txt");

            var completeOverlaps = 0;
            var partialOverlaps = 0;

            foreach (var line in input)
            {
                // 1-1 | 99-99
                var areas = line.Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .SelectMany(elves => elves.Split("-", StringSplitOptions.RemoveEmptyEntries))
                                .Select(int.Parse)
                                .ToArray();

                var rangeOne = areas[0]..areas[1];
                var rangeTwo = areas[2]..areas[3];

                if (// Range One Contains Range Two
                    (rangeOne.Start.Value <= rangeTwo.Start.Value &&
                    rangeOne.End.Value >= rangeTwo.End.Value) ||
                    // Range Two Contains Range One
                    (rangeTwo.Start.Value <= rangeOne.Start.Value &&
                    rangeTwo.End.Value >= rangeOne.End.Value))
                {
                    completeOverlaps++;
                }

                if (rangeOne.Start.Value <= rangeTwo.End.Value && 
                    rangeTwo.Start.Value <= rangeOne.End.Value)
                {
                    partialOverlaps++;
                }
            }

            Console.WriteLine($"Amount of complete overlaps: {completeOverlaps}");
            Console.WriteLine($"Amount of partial overlaps: {partialOverlaps}");

            Console.WriteLine();
            Console.WriteLine("============== End of Code for Day4 ===============");
            Console.WriteLine();
        }
    }
}
