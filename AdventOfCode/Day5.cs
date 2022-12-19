using System.ComponentModel;

namespace AdventOfCode
{
    // https://adventofcode.com/2022/day/5
    internal class Day5
    {
        public static void Run()
        {
            Console.WriteLine("============== Running Code for Day5 ==============");
            Console.WriteLine();

            // Input Data: https://adventofcode.com/2022/day/5/input

            var input = File.ReadAllLines("./Input/Day5.txt");
            var initialContainerSetup = input.Take(8)
                                             .Reverse()
                                             .ToArray();
            var commands = input.Skip(10);

            var partOneContainers = GenerateContainerDictionary(initialContainerSetup);

            // Execute the instructions according to the commands
            foreach (var command in commands)
            {
                var instructions = command.Split(' ');
                var move = int.Parse(instructions[1]);
                var from = int.Parse(instructions[3]);
                var to = int.Parse(instructions[5]);

                for (int i = 0; i < move; i++)
                {
                    var container = partOneContainers[from].Pop();
                    partOneContainers[to].Push(container);
                }
            }

            // Print output
            PrintSolution("Part One solution:", partOneContainers);

            // Part 2
            var partTwoContainers = GenerateContainerDictionary(initialContainerSetup);

            // Execute the instructions according to the commands
            foreach (var command in commands)
            {
                var instructions = command.Split(' ');
                var move = int.Parse(instructions[1]);
                var from = int.Parse(instructions[3]);
                var to = int.Parse(instructions[5]);

                var tmpContainerStack = new Stack<char>();

                // Pop the top containers according to move count
                for (int i = 0; i < move; i++)
                {
                    var container = partTwoContainers[from].Pop();
                    tmpContainerStack.Push(container);
                }

                // Reverse to correct the order
                tmpContainerStack.Reverse();

                // Push tmpContainerStack to simulate multiple container movement
                foreach (var container in tmpContainerStack)
                {
                    partTwoContainers[to].Push(container);
                }
            }

            // Print output
            PrintSolution("Part Two solution:", partTwoContainers);

            Console.WriteLine();
            Console.WriteLine("============== End of Code for Day5 ===============");
            Console.WriteLine();
        }

        private static Dictionary<int, Stack<char>> GenerateContainerDictionary(string[] initialSetup)
        {
            var dictionary = new Dictionary<int, Stack<char>>();

            // Initialize Container Stacks
            for (int i = 1; i < 10; i++)
            {
                dictionary.Add(i, new Stack<char>());
            }

            // Initialize Container content with actual values
            foreach (var line in initialSetup)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] != ' ' && line[i] != '[' && line[i] != ']')
                    {
                        // [B] [T] [M] [B] [J] [C] [T] [G] [N]
                        //  1   2   3   4   5   6   7   8   9
                        // Column is determined by
                        // (i-1)/4 + 1 where i = char-index
                        var column = i == 1 ? 1 : ((i - 1) / 4) + 1;
                        dictionary[column].Push(line[i]);
                    }
                }
            }

            return dictionary;
        }

        private static void PrintSolution(string title, Dictionary<int, Stack<char>> containers)
        {
            Console.WriteLine(title);
            foreach (var container in containers)
            {
                Console.Write(container.Value.Pop());
            }
            Console.WriteLine();
        }
    }
}
