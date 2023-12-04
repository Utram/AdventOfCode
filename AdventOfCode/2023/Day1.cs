using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AdventOfCode.Y2023
{
    // https://adventofcode.com/2023/day/1
    internal class Day1 : Day
    {
        private readonly List<string> _writtenDigits = new List<string> { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
       

        public Day1() : base(2023, 1)
        {
        }

        protected override void RunLogic(string[] input)
        {
            // Part 1

            Console.WriteLine(); 
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Part 1");
            Console.WriteLine();

            var calibrationValues = new List<int>();

            foreach (var line in input)
            {
                var firstDigit = ExtractFirstDigit(line);
                var lastDigit  = ExtractLastDigit(line);

                var calibrationValue = int.Parse(firstDigit.ToString() + lastDigit.ToString());

                calibrationValues.Add(calibrationValue);
            }

            var sumOfAllCalibrationValues = calibrationValues.Sum();
            
            Console.WriteLine();
            Console.WriteLine($"Sum of all Calibration Values: {sumOfAllCalibrationValues}");
            Console.WriteLine();

            // Part 2

            Console.WriteLine();
            Console.WriteLine("Part 2");
            Console.WriteLine();

            calibrationValues.Clear();

            foreach (var line in input)
            {
                var firstDigit = ExtractFirstDigit(line, true);
                var lastDigit  = ExtractLastDigit(line, true);

                var calibrationValue = int.Parse(firstDigit.ToString() + lastDigit.ToString());

                calibrationValues.Add(calibrationValue);
            }

            sumOfAllCalibrationValues = calibrationValues.Sum();

            Console.WriteLine();
            Console.WriteLine($"Sum of all Calibration Values: {sumOfAllCalibrationValues}");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();
        }

        private int ExtractFirstDigit(string line, bool considerWrittenDigits = false)
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (Char.IsDigit(line[i]))
                {
                    return int.Parse(line[i].ToString());
                }

                if (considerWrittenDigits)
                {
                    var substring = line.Substring(0, i + 1);

                    foreach (var writtenDigit in _writtenDigits)
                    {
                        if (substring.Contains(writtenDigit))
                        {
                            return _writtenDigits.IndexOf(writtenDigit) + 1;
                        }
                    }
                }
            }

            throw new Exception("No digit found");
        }

        private int ExtractLastDigit(string line, bool considerWrittenDigits = false)
        {
            var iteration = 1;

            for (int i = line.Length - 1; i >= 0; i--)
            {
                if (Char.IsDigit(line[i]))
                {
                    return int.Parse(line[i].ToString());
                }

                if (considerWrittenDigits)
                {
                    var substring = line.Substring(line.Length - iteration, iteration);

                    foreach (var writtenDigit in _writtenDigits)
                    {
                        if (substring.Contains(writtenDigit))
                        {
                            return _writtenDigits.IndexOf(writtenDigit) + 1;
                        }
                    }

                    iteration++;
                }
            }

            throw new Exception("No digit found");
        }
    }
}
