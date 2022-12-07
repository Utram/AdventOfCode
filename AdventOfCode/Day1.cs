namespace AdventOfCode
{
    // https://adventofcode.com/2022/day/1
    internal class Day1
    {
        public static void Run()
        {
            Console.WriteLine("============== Running Code for Day1 ==============");
            Console.WriteLine();

            // Input Data: https://adventofcode.com/2022/day/1/input

            var input = File.ReadAllLines("./Input/Day1.txt");
            
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

            Console.WriteLine();
            Console.WriteLine($"Elve #{dictElvesAndCalories.FirstOrDefault(x => x.Value == maxCalories).Key} is carrying {maxCalories} calories.");
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Top three elves are carrying a total of {topThreeTotalCalories} calories.");
            Console.WriteLine();

            foreach (var elve in topThreeElves)
            {
                Console.WriteLine($"Elve #{elve.Key} is carrying {elve.Value} calories.");
            }

            Console.WriteLine();
            Console.WriteLine("============== End of Code for Day1 ==============");
            Console.WriteLine();
        }
    }
}
