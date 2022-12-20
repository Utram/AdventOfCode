using System.ComponentModel;

namespace AdventOfCode
{
    // https://adventofcode.com/2022/day/6
    internal class Day6
    {
        public static void Run()
        {
            Console.WriteLine("============== Running Code for Day6 ==============");
            Console.WriteLine();

            // Input Data: https://adventofcode.com/2022/day/6/input

            var input = File.ReadAllLines("./Input/Day6.txt");

            DetectStartOfMarker("Start-Of-Packet", 4, input[0]);
            DetectStartOfMarker("Start-Of-Message", 14, input[0]);

            Console.WriteLine();
            Console.WriteLine("============== End of Code for Day6 ===============");
            Console.WriteLine();
        }

        private static void DetectStartOfMarker(string markerType, int markerLength, string input)
        {
            var markerDetected = true;
            var index = 0;

            while (markerDetected)
            {
                var distinctCount = input.Skip(index)
                                         .Take(markerLength)
                                         .Distinct()
                                         .Count();

                if (distinctCount == markerLength)
                {
                    markerDetected = false;
                    break;
                }

                index++;
            }

            var marker = input.Substring(index, markerLength);

            Console.WriteLine($"{markerType}");
            Console.WriteLine($"Full marker: {marker}");
            Console.WriteLine($"Marker detected at index: {index + markerLength}");
        }
    }
}