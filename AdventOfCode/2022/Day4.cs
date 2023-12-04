namespace AdventOfCode.Y2022
{
    // https://adventofcode.com/2022/day/4
    internal class Day4 : Day
    {
        public Day4() : base(2022, 4)
        {
        }

        protected override void RunLogic(string[] input)
        {
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
        }
    }
}