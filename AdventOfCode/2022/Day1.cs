namespace AdventOfCode.Y2022
{
    // https://adventofcode.com/2022/day/1
    internal class Day1 : Day
    {
        public Day1() : base(2022, 1)
        {
        }

        protected override void RunLogic(string[] input)
        {
            var i = 0;
            var elveId = 0;
            var currentElveTotalCalories = 0;
            var dictElvesAndCalories = new Dictionary<int, int>();

            while (i < input.Length)
            {
                var currentLine = input[i];

                // Add Elve with calories to dict
                if (string.IsNullOrEmpty(currentLine) || string.IsNullOrWhiteSpace(currentLine))
                {
                    if (currentElveTotalCalories > 0)
                    {
                        dictElvesAndCalories[elveId] = currentElveTotalCalories;
                        currentElveTotalCalories = 0;
                        elveId++;
                    }

                    i++;
                    continue;
                }

                var currentCalories = int.Parse(currentLine);
                currentElveTotalCalories += currentCalories;

                i++;
            }

            var maxCalories = dictElvesAndCalories.Values.Max();

            // Top three elves
            var topThreeElves = dictElvesAndCalories.OrderByDescending(x => x.Value)
                                                    .Take(3)
                                                    .OrderByDescending(x => x.Value);

            // Top Three sum
            var topThreeTotalCalories = topThreeElves.Sum(x => x.Value);

            Console.WriteLine($"Elve #{dictElvesAndCalories.FirstOrDefault(x => x.Value == maxCalories).Key} is carrying {maxCalories} calories.");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Top three elves are carrying a total of {topThreeTotalCalories} calories.");
            Console.WriteLine();

            foreach (var elve in topThreeElves)
            {
                Console.WriteLine($"Elve #{elve.Key} is carrying {elve.Value} calories.");
            }
        }
    }
}